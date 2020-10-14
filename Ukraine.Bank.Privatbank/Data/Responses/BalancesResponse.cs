using System.Text.Json.Serialization;
using Ukraine.Bank.Privatbank.Data.Models;

namespace Ukraine.Bank.Privatbank.Data.Responses
{
    internal class BalancesResponse : BasicResponse
    {
        [JsonPropertyName("balances")] 
        public Balance[] Balances { get; set; }
    }
}