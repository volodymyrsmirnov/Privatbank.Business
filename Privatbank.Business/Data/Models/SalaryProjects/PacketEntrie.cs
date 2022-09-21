using Privatbank.Business.Data.Enums.SalaryProjects;
using System;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Models.SalaryProjects {

    /// <summary>
    /// a list of packet elements
    /// </summary>
    public class PacketEntrie {
        /// <summary>
        /// essentually this is an id. it is not mapped for json
        /// </summary>
        public string packet_reference { get; set; }

        /// <summary>
        /// packet element reference - element id
        /// </summary>
        [JsonPropertyName("ref")]
        public string reference { get; set; }

        /// <summary>
        /// fio
        /// </summary>
        [JsonPropertyName("fio")]
        public string fio { get; set; }

        /// <summary>
        /// inn of person to pay to
        /// </summary>
        [JsonPropertyName("inn")]
        public string inn { get; set; }

        /// <summary>
        /// card number with mask
        /// </summary>
        [JsonPropertyName("cardNumber")]
        public string card_number { get; set; }

        /// <summary>
        /// comment
        /// </summary>
        [JsonPropertyName("comment")]
        public string comment { get; set; }

        /// <summary>
        /// amount
        /// </summary>
        [JsonPropertyName("amount")]
        public decimal amount { get; set; }
        
        /// <summary>
        /// status code
        /// </summary>
        [JsonPropertyName("status")]
        public Packet_Element_Status status { get; set; }

        /// <summary>
        /// err code
        /// </summary>
        [JsonPropertyName("errorCode")]
        public string errorCode { get; set; }

        /// <summary>
        /// tab num
        /// </summary>
        [JsonPropertyName("tabNo")]
        public string tabel_num { get; set; }
    }
}
