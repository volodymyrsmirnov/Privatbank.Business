using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Models {
    /// <summary>
    /// Payment result.
    /// </summary>
    public class PaymentResult {
        /// <summary>
        /// Payment reference.
        /// </summary>
        [JsonPropertyName("payment_ref")]
        public string Reference { get; set; }

        /// <summary>
        /// Payment packed reference.
        /// </summary>
        [JsonPropertyName("payment_pack_ref")]
        public string PackedReference { get; set; }
    }
}