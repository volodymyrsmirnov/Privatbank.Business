using Privatbank.Business.Data.Models.SalaryProjects;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Responses {
    internal class ReceiverResponce : BasicResponse {
        [JsonPropertyName("data")]
        public Receiver[] Receivers { get; set; }
    }
}