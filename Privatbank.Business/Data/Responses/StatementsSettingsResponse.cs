using Privatbank.Business.Data.Models;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Responses {
    internal class StatementsSettingsResponse : BasicResponse {
        [JsonPropertyName("settings")]
        public StatementsSettings Settings { get; set; }
    }
}