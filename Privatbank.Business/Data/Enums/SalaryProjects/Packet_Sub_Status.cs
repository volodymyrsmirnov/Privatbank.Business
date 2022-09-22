using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Enums.SalaryProjects {
    /// <summary>
    /// sub status of a slary project pocket status, <see cref="Packet_Status"/>
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverterWithAttributeSupport))]
    public enum Packet_Sub_Status {
        /// <summary>
        /// packet in review
        /// Пакет на перевірці (N->W, N->N)
        /// </summary>
        [EnumMember(Value = "V")]
        InReview,
        /// <summary>
        /// packet processing data
        /// Пакет обробляє імпорт сирих файлів (N->N)
        /// </summary>
        [EnumMember(Value = "I")]
        Processing,
        /// <summary>
        /// proccessed with no issues
        /// Пакет оброблено без помилок
        /// </summary>
        [EnumMember(Value = "F")]
        Processed,
        /// <summary>
        /// proccessed with issues
        /// Пакет оброблено з помилками
        /// </summary>
        [EnumMember(Value = "R")]
        ProcessedWithIssue,
    }
}
