using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Ukraine.Bank.Privatbank.Data.Models;
using Ukraine.Bank.Privatbank.Data.Responses;
using Ukraine.Bank.Privatbank.Exceptions;

namespace Ukraine.Bank.Privatbank
{
    public class PrivatbankAutoClient : IDisposable
    {
        private const string ApiBaseAddress = "https://acp.privatbank.ua/api/";
        private const int RecordsPerBatch = 20;
        private readonly HttpClient _httpClient;

        public PrivatbankAutoClient(string clientId, string clientToken)
        {
            if (string.IsNullOrEmpty(clientId))
                throw new ArgumentNullException(nameof(clientId));

            if (string.IsNullOrEmpty(clientToken))
                throw new ArgumentNullException(nameof(clientToken));

            var currentAssemblyName = Assembly.GetCallingAssembly().GetName();

            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(ApiBaseAddress)
            };

            _httpClient.DefaultRequestHeaders.Add("id", clientId);
            _httpClient.DefaultRequestHeaders.Add("token", clientToken);

            _httpClient.DefaultRequestHeaders.UserAgent.Add(
                new ProductInfoHeaderValue(currentAssemblyName.Name, currentAssemblyName.Version.ToString()));
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }

        private async Task<T> GetDataFromApi<T>(string uri)
        {
            var response = await _httpClient.PostAsync(uri,
                new StringContent(string.Empty, Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();

            return await JsonSerializer.DeserializeAsync<T>(
                await response.Content.ReadAsStreamAsync());
        }

        public async Task<StatementsSettings> GetStatementsSettingsAsync()
        {
            var response = await GetDataFromApi<StatementsSettingsResponse>("statements/settings");

            if (!response.Success)
                throw new PrivatbankStatusException();

            return response.Settings;
        }

        private string GetUriWithParameters(string uri, string account = null, DateTime? startDate = null,
            DateTime? endDate = null, string followId = null)
        {
            uri += $"?limit={RecordsPerBatch}";

            if (!string.IsNullOrEmpty(account))
                uri += "&acc=" + HttpUtility.UrlEncode(account);

            if (startDate != null)
                uri += "&startDate=" + HttpUtility.UrlEncode(startDate.Value.ToString("dd-MM-yyyy"));

            if (endDate != null)
                uri += "&endDate=" + HttpUtility.UrlEncode(endDate.Value.ToString("dd-MM-yyyy"));

            if (!string.IsNullOrEmpty(followId))
                uri += "&followId=" + HttpUtility.UrlEncode(followId);

            return uri;
        }

        private async Task<T[]> GetResponseRecords<TR, T>(string uri, Func<TR, T[]> getter, string account = null,
            DateTime? startDate = null, DateTime? endDate = null) where TR : BasicResponse
        {
            var result = new List<T>();

            var hasPagination = true;
            var nextPageId = string.Empty;

            while (hasPagination)
            {
                var response = await GetDataFromApi<TR>(
                    GetUriWithParameters(uri, account, startDate, endDate, nextPageId));

                hasPagination = response.HasPagination;
                nextPageId = response.NextPageId;

                if (!response.Success)
                    throw new PrivatbankStatusException();

                result.AddRange(getter(response));
            }

            return result.ToArray();
        }

        public async Task<Balance[]> GetBalanceAsync(DateTime startDate, string account = null, 
            DateTime? endDate = null)
        {
            return await GetResponseRecords<BalancesResponse, Balance>(
                "statements/balance", r => r.Balances, account, startDate, endDate);
        }

        public async Task<Balance[]> GetBalanceInterimAsync(string account = null)
        {
            return await GetResponseRecords<BalancesResponse, Balance>(
                "statements/balance/interim", r => r.Balances, account);
        }

        public async Task<Balance[]> GetBalanceFinalAsync(string account = null)
        {
            return await GetResponseRecords<BalancesResponse, Balance>(
                "statements/balance/final", r => r.Balances, account);
        }
        
        public async Task<Transaction[]> GetTransactionsAsync(DateTime startDate, string account = null, 
            DateTime? endDate = null)
        {
            return await GetResponseRecords<TransactionsResponse, Transaction>(
                "statements/transactions", r => r.Transactions, account, startDate, endDate);
        }

        public async Task<Transaction[]> GetTransactionsInterimAsync(string account = null)
        {
            return await GetResponseRecords<TransactionsResponse, Transaction>(
                "statements/transactions/interim", r => r.Transactions, account);
        }

        public async Task<Transaction[]> GetTransactionsFinalAsync(string account = null)
        {
            return await GetResponseRecords<TransactionsResponse, Transaction>(
                "statements/transactions/final", r => r.Transactions, account);
        }
    }
}