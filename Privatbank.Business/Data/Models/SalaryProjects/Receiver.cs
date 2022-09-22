using Privatbank.Business.Data.Enums.SalaryProjects;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Models.SalaryProjects {

    /// <summary>
    /// is a receiver in a packet, is the main object in packet element
    /// </summary>
    public class Receiver {
        /// <summary>
        /// id
        /// </summary>
        [JsonPropertyName("id")]
        public string id { get; set; }

        /// <summary>
        /// masked card number
        /// </summary>
        [JsonPropertyName("pan")]
        public string card_masked { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonPropertyName("fio")]
        public List<string> fio { get; set; }
        /// <summary>
        /// 10 digit num
        /// </summary>
        [JsonPropertyName("inn")]
        public string inn { get; set; }
        /// <summary>
        /// <see cref="GroupType"/>
        /// </summary>
        [JsonPropertyName("group")]
        public GroupType group_type { get; set; }
        /// <summary>
        /// tabel number
        /// </summary>
        [JsonPropertyName("tabn")]
        public string tab_num { get; set; }
    }
}
