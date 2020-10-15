using System.Text.Json.Serialization;
using Privatbank.Business.Data.Models;

namespace Privatbank.Business.Data.Responses
{
    internal class StatementsSettingsResponse : BasicResponse
    {
        [JsonPropertyName("settings")]
        public StatementsSettings Settings { get; set; }
    }
}