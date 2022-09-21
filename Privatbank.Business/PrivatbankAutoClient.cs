using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Privatbank.Business.Data.Models;
using Privatbank.Business.Data.Models.SalaryProjects;
using Privatbank.Business.Data.Responses;
using Privatbank.Business.Exceptions;

namespace Privatbank.Business {
    /// <summary>
    /// Privatbank API AutoClient. for api 3.0.0
    /// </summary>
    public class PrivatbankAutoClient : IDisposable
    {
        private const string ApiBaseAddress = "https://acp.privatbank.ua/api/";
        private const int RecordsPerBatch = 20;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Initialize API AutoClient.
        /// </summary>
        /// <param name="clientToken">Client token.</param>
        /// <exception cref="ArgumentNullException">Mandatory parameter has not been provided.</exception>
        public PrivatbankAutoClient(string clientToken)
        {
            if (string.IsNullOrEmpty(clientToken))
                throw new ArgumentNullException(nameof(clientToken));

            _httpClient = new HttpClient {
                BaseAddress = new Uri(ApiBaseAddress)
            };
            _httpClient.DefaultRequestHeaders.Add("token", clientToken);
        }

        /// <summary>
        /// Dispose API client.
        /// </summary>
        public void Dispose()
        {
            _httpClient.Dispose();
        }

        private async Task<TResponse> GetDataFromApi<TResponse>(string uri) where TResponse : BasicResponse {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
            // the only normal way to set encoding for a request, it seems
            request.Content = new StringContent(string.Empty, Encoding.UTF8, "application/json"); ;
            
            var response = await _httpClient.SendAsync(request);
            var data = await JsonSerializer.DeserializeAsync<TResponse>(
                await response.Content.ReadAsStreamAsync());

            if (!response.IsSuccessStatusCode)
                throw new PrivatbankResponseException(data.ErrorCode, data.ErrorMessage);

            return data;
        }

        private async Task<TRecord[]> GetRecordsFromApi<TResponse, TRecord>(string uri,
            Func<TResponse, TRecord[]> getter, string account = null, DateTime? startDate = null,
            DateTime? endDate = null) where TResponse : BasicResponse
        {
            var result = new List<TRecord>();

            var hasPagination = true;
            string nextPageId = null;

            while (hasPagination)
            {
                var response = await GetDataFromApi<TResponse>(
                    BuildUri(uri, account, startDate, endDate, nextPageId));

                hasPagination = response.HasPagination;
                nextPageId = response.NextPageId;

                result.AddRange(getter(response));
            }

            return result.ToArray();
        }

        private static string BuildUri(string uri, string account = null, DateTime? startDate = null,
            DateTime? endDate = null, string followId = null)
        {
            var uriBuilder = new StringBuilder($"{uri}?limit={RecordsPerBatch}");

            if (!string.IsNullOrEmpty(account))
                uriBuilder.Append($"&acc={HttpUtility.UrlEncode(account)}");

            if (startDate != null)
                uriBuilder.Append($"&startDate={startDate.Value:dd-MM-yyyy}");

            if (endDate != null)
                uriBuilder.Append($"&endDate={endDate.Value:dd-MM-yyyy}");

            if (!string.IsNullOrEmpty(followId))
                uriBuilder.Append($"&followId={HttpUtility.UrlEncode(followId)}");

            return uriBuilder.ToString();
        }

        #region StamementsSettings

        /// <summary>
        /// Get statements settings.
        /// </summary>
        /// <returns><see cref="StatementsSettings"/></returns>
        public async Task<StatementsSettings> GetStatementsSettingsAsync()
        {
            var response = await GetDataFromApi<StatementsSettingsResponse>("statements/settings");

            return response.Settings;
        }

        #endregion

        #region Payments

        /// <summary>
        /// Create new payment.
        /// </summary>
        /// <param name="payment"><see cref="Payment"/></param>
        /// <returns><see cref="PaymentResult"/></returns>
        /// <exception cref="PrivatbankResponseException">Error occured during the payment creation.</exception>
        public async Task<PaymentResult> CreatePaymentAsync(Payment payment) {
            var response = await _httpClient.PostAsync("proxy/payment/create",
                new StringContent(JsonSerializer.Serialize(payment), Encoding.UTF8, "application/json"));

            if (response.IsSuccessStatusCode)
                return await JsonSerializer.DeserializeAsync<PaymentResult>(
                    await response.Content.ReadAsStreamAsync());

            var error = await JsonSerializer.DeserializeAsync<BasicResponse>(
                await response.Content.ReadAsStreamAsync());

            throw new PrivatbankResponseException(error.ErrorCode, error.ErrorMessage);
        }

        #endregion

        #region Balance

        /// <summary>
        /// Get balance sheet.
        /// </summary>
        /// <param name="startDate">Starting date.</param>
        /// <param name="account">Account number.</param>
        /// <param name="endDate">End date.</param>
        /// <returns><see cref="Balance"/></returns>
        public async Task<Balance[]> GetBalanceAsync(DateTime startDate, string account = null,
            DateTime? endDate = null) {
            return await GetRecordsFromApi<BalancesResponse, Balance>(
                "statements/balance", r => r.Balances, account, startDate, endDate);
        }

        /// <summary>
        /// Get interim balance sheet.
        /// </summary>
        /// <param name="account">Account number.</param>
        /// <returns><see cref="Balance"/></returns>
        public async Task<Balance[]> GetBalanceInterimAsync(string account = null)
        {
            return await GetRecordsFromApi<BalancesResponse, Balance>(
                "statements/balance/interim", r => r.Balances, account);
        }

        /// <summary>
        /// Get final balance sheet.
        /// </summary>
        /// <param name="account">Account number.</param>
        /// <returns><see cref="Balance"/></returns>
        public async Task<Balance[]> GetBalanceFinalAsync(string account = null)
        {
            return await GetRecordsFromApi<BalancesResponse, Balance>(
                "statements/balance/final", r => r.Balances, account);
        }

        #endregion

        #region Transactions

        /// <summary>
        /// Get transactions.
        /// </summary>
        /// <param name="startDate">Start date.</param>
        /// <param name="account">Account.</param>
        /// <param name="endDate">End date.</param>
        /// <returns><see cref="Transaction"/></returns>
        public async Task<Transaction[]> GetTransactionsAsync(DateTime startDate, string account = null,
            DateTime? endDate = null)
        {
            return await GetRecordsFromApi<TransactionsResponse, Transaction>(
                "statements/transactions", r => r.Transactions, account, startDate, endDate);
        }

        /// <summary>
        /// Get interim transactions.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <returns><see cref="Transaction"/></returns>
        public async Task<Transaction[]> GetTransactionsInterimAsync(string account = null)
        {
            return await GetRecordsFromApi<TransactionsResponse, Transaction>(
                "statements/transactions/interim", r => r.Transactions, account);
        }

        /// <summary>
        /// Get final transactions.
        /// </summary>
        /// <param name="account">Account.</param>
        /// <returns><see cref="Transaction"/></returns>
        public async Task<Transaction[]> GetTransactionsFinalAsync(string account = null)
        {
            return await GetRecordsFromApi<TransactionsResponse, Transaction>(
                "statements/transactions/final", r => r.Transactions, account);
        }

        #endregion

        /// <summary>
        /// Get salary groups.
        /// </summary>
        /// <returns><see cref="Group"/></returns>
        public async Task<Group[]> GetGroupsAsync() {
            return await GetRecordsFromApi<GroupsResponse, Group>(
                "pay/mp/list-groups", r => r.Groups);
        }

        /// <summary>
        /// return Packets list, these are salary project packets 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Packet>> GetPacketsAsync(DateTime from, DateTime to) {
            // IMPORTANT: this code reapeats? I dont want to refactor the whole nuget for this
            List<Packet> result = new List<Packet>();
            PacketsResponse responce;
            string api_path;
            int page = 0, page_size = 100; //page_size max 100 for api
            // this is ugly because there already is  method for pagination? yes, but it uses other query parameters, so no.
            do {
                api_path = $"pay/apay24/packets/list?page={page}&page-size={page_size}&from={from:yyyy-MM-dd}&to={to:yyyy-MM-dd}";
                responce = await GetDataFromApi<PacketsResponse>(api_path);

                result.AddRange(responce.Packets);
                page++;
            } while (responce.Packets.Length == 100);
            return result;
        }

        /// <summary>
        /// get packet entries af a packet
        /// </summary>
        /// <param name="packet">a packet returned by api peforehand, or just it ref num</param>
        /// <returns>list of all entries for a specific packet</returns>
        public async Task<List<PacketEntrie>> GetPacketEntriesAsync(Packet packet) {
            // IMPORTANT: this code reapeats? I dont want to refactor the whole nuget for this
            // no switch because there is no public api for any other then "maspay", although I`m sure the other one is identical
            // and has endpoint */reqpay/*
            // so for know - no
            //switch (packet.system)
            List<PacketEntrie> result = new List<PacketEntrie>();
            PacketEntriesResponse responce;
            string api_path;
            int page = 0, page_size = 100; //page_size max 100 for api
            // this is ugly because there already is  method for pagination? yes, but it uses other query parameters, so no.
            do {
                api_path = $"pay/maspay/{packet.reference}/content?page={page}&page-size={page_size}";
                responce = await GetDataFromApi<PacketEntriesResponse>(api_path);

                result.AddRange(responce.PacketEntries);
                page++;
            } while (responce.PacketEntries.Length == 100);
            return result;
        }
    }
}