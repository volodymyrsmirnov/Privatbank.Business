using Privatbank.Business.Data.Models.SalaryProjects;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Enums.SalaryProjects {
    /// <summary>
    /// salary project packet status, <see cref="Packet"/> and for sub-status <see cref="Packet_Sub_Status"/>
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverterWithAttributeSupport))]
    public enum Packet_Status {
        /// <summary>
        /// created
        /// Пакет створено, і допускає редагування
        /// </summary>
        [EnumMember(Value = "N")]
        Created,
        /// <summary>
        /// reviewed
        /// Пакет пройшов успішну перевірку, і його можна затвердити, або відізвати на редагування
        /// </summary>
        [EnumMember(Value = "W")]
        Reviewd,
        /// <summary>
        /// confirmed - awaits singed
        /// Пакет затверджено, і може бути підписаний або видалений
        /// </summary>
        [EnumMember(Value = "S")]
        NotSinged,
        /// <summary>
        /// signed by accountant
        /// Пакет очікує підпис директора
        /// </summary>
        [EnumMember(Value = "SB")]
        SingedAccountant,
        /// <summary>
        /// singed by director
        /// Пакет очікує підпис бухгалтера
        /// </summary>
        [EnumMember(Value = "SD")]
        SingedDirector,

        /// <summary>
        /// fully reviewed
        /// Пакет отримав всі необхідні підписи і може бути відправлений в банк
        /// </summary>
        [EnumMember(Value = "S$")]
        ToBeSent,

        /// <summary>
        /// sent
        /// Пакет відправлено в банк на обробку
        /// </summary>
        [EnumMember(Value = "X")]
        ToBePaid,
        /// <summary>
        /// In review
        /// Has Sub_status <see cref="Packet_Sub_Status"/>
        /// Пакет на перевірці (N->W, N->N)
        /// </summary>
        [EnumMember(Value = "N")]
        InRiview,
        /// <summary>
        /// proccessed, for more details <see cref="Packet_Sub_Status"/>
        /// Has Sub_status 
        /// Пакет оброблено без помилок
        /// </summary>
        [EnumMember(Value = "F")]
        Processed,
        /// <summary>
        /// blocked
        /// Пакет забраковано
        /// </summary>
        [EnumMember(Value = "R")]
        Blocked,
        /// <summary>
        /// deleted
        /// Пакет видалено
        /// </summary>
        [EnumMember(Value = "D")]
        Deleted
    }
}
