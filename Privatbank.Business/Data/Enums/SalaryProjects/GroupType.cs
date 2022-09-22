using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Enums.SalaryProjects {
    /// <summary>
    /// group salary type
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverterWithAttributeSupport))]
    public enum GroupType {
        /// <summary>
        /// project type
        /// </summary>
        MASSPAYMENTS,
        /// <summary>
        /// other salary projects
        /// </summary>
        SALARY,
        /// <summary>
        /// project type
        /// </summary>
        STUDENT,
        /// <summary>
        /// project type
        /// </summary>
        HESED,
        /// <summary>
        /// use this ALL for request about salary group members
        /// </summary>
        ALL,
    }
}
