using Privatbank.Business.Data.Models.SalaryProjects;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Responses {
    internal class PacketEntriesResponse : BasicResponse {
        [JsonPropertyName("data")]
        public PacketEntrie[] PacketEntries { get; set; }
    }
}
