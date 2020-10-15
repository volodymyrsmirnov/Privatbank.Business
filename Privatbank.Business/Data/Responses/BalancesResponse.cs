using System.Text.Json.Serialization;
using Privatbank.Business.Data.Models;

namespace Privatbank.Business.Data.Responses
{
    internal class BalancesResponse : BasicResponse
    {
        [JsonPropertyName("balances")]
        public Balance[] Balances { get; set; }
    }
}