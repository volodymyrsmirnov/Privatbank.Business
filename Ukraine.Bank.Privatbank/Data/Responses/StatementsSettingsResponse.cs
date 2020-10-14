using System.Text.Json.Serialization;
using Ukraine.Bank.Privatbank.Data.Models;

namespace Ukraine.Bank.Privatbank.Data.Responses
{
    internal class StatementsSettingsResponse : BasicResponse
    {
        [JsonPropertyName("settings")] 
        public StatementsSettings Settings { get; set; }
    }
}