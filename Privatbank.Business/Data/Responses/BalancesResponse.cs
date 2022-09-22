using Privatbank.Business.Data.Models;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Responses {
    internal class BalancesResponse : BasicResponse {
        [JsonPropertyName("balances")]
        public Balance[] Balances { get; set; }
    }
}