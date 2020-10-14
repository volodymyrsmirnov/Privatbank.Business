using System;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Ukraine.Bank.Privatbank.Test
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
        
        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
        }
    }
}