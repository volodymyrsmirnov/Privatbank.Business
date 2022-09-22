using Privatbank.Business.Data.Models.SalaryProjects;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Responses {
    internal class GroupsResponse : BasicResponse {
        [JsonPropertyName("data")]
        public Group[] Groups { get; set; }
    }
}
