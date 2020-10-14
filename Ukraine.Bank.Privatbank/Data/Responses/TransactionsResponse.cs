using System.Text.Json.Serialization;
using Ukraine.Bank.Privatbank.Data.Models;

namespace Ukraine.Bank.Privatbank.Data.Responses
{
    internal class TransactionsResponse : BasicResponse
    {
        [JsonPropertyName("transactions")] 
        public Transaction[] Transactions { get; set; }
    }
}