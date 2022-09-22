using System.Text.Json.Serialization;
using Privatbank.Business.Data.Models;
using Privatbank.Business.Data.Models.SalaryProjects;

namespace Privatbank.Business.Data.Responses
{
    internal class ReceiverResponce : BasicResponse
    {
        [JsonPropertyName("data")]
        public Receiver[] Receivers { get; set; }
    }
}