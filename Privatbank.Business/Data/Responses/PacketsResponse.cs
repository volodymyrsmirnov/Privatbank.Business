using System.Text.Json.Serialization;
using Privatbank.Business.Data.Models.SalaryProjects;

namespace Privatbank.Business.Data.Responses {
    internal class PacketsResponse : BasicResponse {
        [JsonPropertyName("data")]
        public Packet[] Packets { get; set; }
    }
}
