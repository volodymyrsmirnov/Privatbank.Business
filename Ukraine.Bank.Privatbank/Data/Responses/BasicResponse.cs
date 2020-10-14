using System.Text.Json.Serialization;
using Ukraine.Bank.Privatbank.Converters;

namespace Ukraine.Bank.Privatbank.Data.Responses
{
    internal abstract class BasicResponse
    {
        [JsonPropertyName("status")]
        [JsonConverter(typeof(StatusConverter))]
        public bool Success { get; set; }

        [JsonPropertyName("exist_next_page")] public bool HasPagination { get; set; }

        [JsonPropertyName("next_page_id")] public string NextPageId { get; set; }
    }
}