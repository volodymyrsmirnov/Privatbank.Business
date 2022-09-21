using System.Text.Json.Serialization;
using Privatbank.Business.Data.Models.SalaryProjects;

namespace Privatbank.Business.Data.Responses {
    internal class GroupsResponse : BasicResponse {
        [JsonPropertyName("data")]
        public Group[] Groups { get; set; }
    }
}
