using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Ukraine.Bank.Privatbank.Converters;

namespace Ukraine.Bank.Privatbank.Data.Models
{
    public class StatementsSettings
    {
        [JsonPropertyName("phase")] public string Phase { get; set; }

        [JsonPropertyName("dates_without_oper_day")]
        [JsonConverter(typeof(DateTimeArrayConverter))]
        public DateTime[] NonOperationalDays { get; set; }

        [JsonPropertyName("today")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CurrentOperationalDay { get; set; }

        [JsonPropertyName("lastday")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime PreviousOperationalDay { get; set; }

        [JsonPropertyName("work_balance")]
        [JsonConverter(typeof(YesNoConverter))]
        public bool WorkBalance { get; set; }

        [JsonPropertyName("server_date_time")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ServerDateTime { get; set; }

        [JsonPropertyName("date_final_statement")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime DateTimeOfFinalStatement { get; set; }
    }
}