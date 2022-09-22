using Privatbank.Business.Data.Models.SalaryProjects;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Enums.SalaryProjects {
    /// <summary>
    /// salary packet element status <see cref="PacketEntrie"/>
    /// N Запис ще не перевірявся
    /// N$ У записі є помилка, яку можна виправити у веб інтерфейсі Приват24 для бізнесу(наприклад 0 сума)
    /// R Успішно перевірена
    /// M Успішно сплачено
    /// E Забракована
    /// * Все останнє можна вважати помилками, на які не можливо повпливати
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverterWithAttributeSupport))]
    public enum Packet_Element_Status {
        /// <summary>
        /// N Запис ще не перевірявся
        /// </summary>
        [EnumMember(Value = "N")]
        Not_reviewed,
        /// <summary>
        /// can be fixed in interface
        /// </summary>
        [EnumMember(Value = "N$")]
        Can_be_fixed,
        /// <summary>
        /// successfully reviewed and accepted, awaits payment
        /// </summary>
        [EnumMember(Value = "R")]
        Reviewed,
        /// <summary>
        /// paid
        /// </summary>
        [EnumMember(Value = "M")]
        Successfully_paid,
        /// <summary>
        /// rejectd
        /// </summary>
        [EnumMember(Value = "E")]
        Rejected,
        /// <summary>
        /// all after unfixable
        /// </summary>
        [EnumMember(Value = "*")]
        All_bad,
    }
}
