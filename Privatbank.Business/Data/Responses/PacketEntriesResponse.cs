using System.Text.Json.Serialization;
using Privatbank.Business.Data.Models.SalaryProjects;

namespace Privatbank.Business.Data.Responses {
    internal class PacketEntriesResponse : BasicResponse {
        [JsonPropertyName("data")]
        public PacketEntrie[] PacketEntries { get; set; }
    }
}
