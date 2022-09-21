using Privatbank.Business.Converters;
using Privatbank.Business.Data.Enums.SalaryProjects;
using System;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Models.SalaryProjects {

    /// <summary>
    /// slsry projects consist of packets
    /// so you have groups and packets. Packets have people to pay to
    /// </summary>
    public class Packet {
        /// <summary>
        /// essentually this is an id
        /// </summary>
        [JsonPropertyName("reference")]
        public string reference { get; set; }

        /// <summary>
        /// salary system type
        /// </summary>
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [JsonPropertyName("system")]
        public SalarySystem system { get; set; }

        /// <summary>
        /// created at
        /// </summary>
        [JsonPropertyName("createdAt")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime created_at { get; set; }

        /// <summary>
        /// finished at
        /// </summary>
        [JsonPropertyName("finishedAt")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime finished_at { get; set; }

        /// <summary>
        /// status, <see cref="Packet_Status"/>
        /// </summary>
        [JsonPropertyName("status")]
        public Packet_Status status { get; set; }


        /// <summary>
        /// sub status <see cref="Packet_Sub_Status"/>
        /// </summary>
        [JsonPropertyName("substatus")]
        public Packet_Sub_Status sub_status { get; set; }

        /// <summary>
        /// name
        /// </summary>
        [JsonPropertyName("packetName")]
        public string name { get; set; }

        /// <summary>
        /// count of list of person+sum
        /// кількість записів
        /// </summary>
        [JsonPropertyName("recordCount")]
        public int record_count { get; set; }

        /// <summary>
        /// full packet sum
        /// повна сума відомості
        /// </summary>
        [JsonPropertyName("recordAmount")]
        public decimal amount { get; set; }

        /// <summary>
        /// revision version
        /// монотонно зростаючий внутрішній лічильник модифікацій
        /// </summary>
        [JsonPropertyName("revision")]
        public int revision { get; set; }
    }
}
