using System;
using System.Threading.Tasks;
using NUnit.Framework;
using Privatbank.Business.Data.Models;

namespace Privatbank.Business.Tests
{
    public class Tests
    {
        private PrivatbankAutoClient _client;

        [SetUp]
        public void SetUp()
        {
            _client = new PrivatbankAutoClient(
                Environment.GetEnvironmentVariable("CLIENT_TOKEN"));
        }

        #region Balance

        [Test]
        public async Task TestGetBalance() {
            var result = await _client.GetBalanceAsync(DateTime.Now);

            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task TestGetBalanceInterim() {
            var result = await _client.GetBalanceInterimAsync();

            Assert.IsNotEmpty(result);
        }


        [Test]
        public async Task TestGetBalanceFinal() {
            var result = await _client.GetBalanceFinalAsync();

            Assert.IsNotEmpty(result);
        } 
        #endregion
        
        [Test]
        public async Task TestStatementsSettings()
        {
            var result = await _client.GetStatementsSettingsAsync();

            Assert.IsNotEmpty(result.Phase);
            Assert.IsNotEmpty(result.NonOperationalDays);
            Assert.AreNotEqual(result.PreviousOperationalDay, DateTime.MinValue);
            Assert.AreNotEqual(result.CurrentOperationalDay, DateTime.MinValue);
            Assert.AreNotEqual(result.ServerDateTime, DateTime.MinValue);
            Assert.AreNotEqual(result.DateTimeOfFinalStatement, DateTime.MinValue);
        }

        #region Transactions
        [Test]
        public async Task TestGetTransactions() {
            var result = await _client.GetTransactionsAsync(
                DateTime.Now - TimeSpan.FromDays(30));

            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task TestGetTransactionsInterim() {
            var result = await _client.GetTransactionsInterimAsync();
            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task TestGetTransactionsFinal() {
            var result = await _client.GetTransactionsFinalAsync();

            Assert.NotNull(result);
        }
        #endregion
        [Test]
        public async Task TestGetRecipientsAsync() {
            var recipeints = await _client.GetRecipientsAsync(new Data.Models.SalaryProjects.Group { type = Data.Enums.SalaryProjects.GroupType.SALARY});
            Assert.NotNull(recipeints);
        }

        [Test]
        public async Task TestGetGroups() {
            var result = await _client.GetGroupsAsync();
            if (result.Count != 0) {
                Assert.IsTrue(result[0].comission_rate >= 0);
                Assert.IsTrue(result[0].comission_rate < 1);
            }
            Assert.NotNull(result);
        }

        [Test]
        public async Task TestGetPackets() {
            var result = await _client.GetPacketsAsync(new DateTime(2022, 1, 1), new DateTime(2023, 1, 1));
            if (result.Count != 0) {
                Assert.IsTrue(result[0].amount >= 0);
            }
            Assert.NotNull(result);
        }
        [Test]
        public async Task TestGetPacketElements() {
            var packets = await _client.GetPacketsAsync(new DateTime(2022, 1, 1), new DateTime(2023, 1, 1));
            if (packets.Count == 0) {
                return;
            }
            var elements = await _client.GetPacketEntriesAsync(packets[0]);
            if (elements.Count > 0) {
                Assert.IsTrue(elements[0].amount > 0);
            }
            Assert.NotNull(elements);
        }

        /*[Test]
        public async Task TestCreatePayment()
        {
            var result = await _client.CreatePaymentAsync(new Payment
            {
                DocumentNumber = "1",
                PayerAccount = Environment.GetEnvironmentVariable("PAYER_ACCOUNT"),
                RecipientCode = "00034022",
                RecipientAccount = "UA458201720313281002302018611",
                PaymentNaming = "Міністерство оборони України",
                PaymentAmount = 1000,
                PaymentDestination = "Грошовий благодійний внесок на матеріально-технічне " +
                                     "забезпечення Збройних Сил України"
            });

            Assert.NotNull(result.Reference);
            Assert.NotNull(result.PackedReference);
    }*/

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}