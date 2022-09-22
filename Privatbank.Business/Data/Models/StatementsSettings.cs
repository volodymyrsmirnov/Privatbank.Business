using Privatbank.Business.Converters;
using System;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Models {
    /// <summary>
    /// Statements settings.
    /// </summary>
    public class StatementsSettings {
        /// <summary>
        /// Operational phase of the bank.
        /// </summary>
        [JsonPropertyName("phase")]
        public string Phase { get; set; }

        /// <summary>
        /// Non-operational days.
        /// </summary>
        [JsonPropertyName("dates_without_oper_day")]
        [JsonConverter(typeof(StringDateTimeArrayConverter))]
        public DateTime[] NonOperationalDays { get; set; }

        /// <summary>
        /// Current operational day.
        /// </summary>
        [JsonPropertyName("today")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime CurrentOperationalDay { get; set; }

        /// <summary>
        /// Last operational day.
        /// </summary>
        [JsonPropertyName("lastday")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime PreviousOperationalDay { get; set; }

        /// <summary>
        /// Balance can be updated.
        /// </summary>
        [JsonPropertyName("work_balance")]
        [JsonConverter(typeof(StringYesNoConverter))]
        public bool WorkBalance { get; set; }

        /// <summary>
        /// Server date and time.
        /// </summary>
        [JsonPropertyName("server_date_time")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime ServerDateTime { get; set; }

        /// <summary>
        /// Date and time of final statements for balance and transactions.
        /// </summary>
        [JsonPropertyName("date_final_statement")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime DateTimeOfFinalStatement { get; set; }
    }
}