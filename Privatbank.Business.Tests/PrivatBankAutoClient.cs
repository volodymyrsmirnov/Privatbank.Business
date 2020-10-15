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
                Environment.GetEnvironmentVariable("CLIENT_ID"),
                Environment.GetEnvironmentVariable("CLIENT_TOKEN"));
        }

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

        [Test]
        public async Task TestGetBalance()
        {
            var result = await _client.GetBalanceAsync(DateTime.Now);

            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task TestGetBalanceInterim()
        {
            var result = await _client.GetBalanceInterimAsync();

            Assert.IsNotEmpty(result);
        }


        [Test]
        public async Task TestGetBalanceFinal()
        {
            var result = await _client.GetBalanceFinalAsync();

            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task TestGetTransactions()
        {
            var result = await _client.GetTransactionsAsync(
                DateTime.Now - TimeSpan.FromDays(30));

            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task TestGetTransactionsInterim()
        {
            var result = await _client.GetTransactionsInterimAsync();

            Assert.IsNotEmpty(result);
        }

        [Test]
        public async Task TestGetTransactionsFinal()
        {
            var result = await _client.GetTransactionsFinalAsync();

            Assert.NotNull(result);
        }

        [Test]
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
        }

        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}