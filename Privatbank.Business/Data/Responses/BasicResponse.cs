using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Responses {
    internal class BasicResponse {
        [JsonPropertyName("exist_next_page")]
        public bool HasPagination { get; set; }

        [JsonPropertyName("next_page_id")]
        public string NextPageId { get; set; }

        [JsonPropertyName("code")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("message")]
        public string ErrorMessage { get; set; }
    }
}