using System.Text.Json.Serialization;
using Privatbank.Business.Data.Models;

namespace Privatbank.Business.Data.Responses
{
    internal class TransactionsResponse : BasicResponse
    {
        [JsonPropertyName("transactions")]
        public Transaction[] Transactions { get; set; }
    }
}