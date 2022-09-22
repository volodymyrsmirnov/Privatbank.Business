using Privatbank.Business.Data.Models;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Responses {
    internal class TransactionsResponse : BasicResponse {
        [JsonPropertyName("transactions")]
        public Transaction[] Transactions { get; set; }
    }
}