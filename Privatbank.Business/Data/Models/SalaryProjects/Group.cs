using Privatbank.Business.Converters;
using Privatbank.Business.Data.Enums.SalaryProjects;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Models.SalaryProjects {

    /// <summary>
    /// payment groups, <see href="https://docs.google.com/document/d/e/2PACX-1vTtKvGa3P4E-lDqLg3bHRF6Wi9S7GIjSMFEFxII5qQZBGxuTXs25hQNiUU1hMZQhOyx6BNvIZ1bVKSr/pub#kix.e65wvlbrhav4">more on salary groups</see> (7. Зарплатний проект)
    /// 
    /// </summary>
    public class Group {
        /// <summary>
        /// more in GroupType documentation
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("type")]
        public GroupType type { get; set; }

        /// <summary>
        /// bank comission rate for group
        /// name in json - "rko"
        /// </summary>
        [JsonPropertyName("rko")]
        public decimal comission_rate { get; set; }

        /// <summary>
        /// salary group name
        /// </summary>
        [JsonPropertyName("name")]
        public string Name { get; set; }

    }
}
