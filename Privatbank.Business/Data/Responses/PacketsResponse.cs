using Privatbank.Business.Data.Models.SalaryProjects;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Responses {
    internal class PacketsResponse : BasicResponse {
        [JsonPropertyName("data")]
        public Packet[] Packets { get; set; }
    }
}
