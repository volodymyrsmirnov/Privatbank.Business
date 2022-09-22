using System;
using System.Text.Json.Serialization;

namespace Privatbank.Business.Data.Models {
    /// <summary>
    /// Outgoing payment record.
    /// </summary>
    public class Payment {
        /// <summary>
        /// Document number.
        /// </summary>
        [JsonPropertyName("document_number")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Payer account.
        /// </summary>
        [JsonPropertyName("payer_account")]
        public string PayerAccount { get; set; }

        /// <summary>
        /// Recipient account number.
        /// </summary>
        [JsonPropertyName("recipient_account")]
        public string RecipientAccount { get; set; }

        /// <summary>
        /// Recipient card.
        /// </summary>
        [JsonPropertyName("recipient_card")]
        public string RecipientCard { get; set; }

        /// <summary>
        /// Recipient code.
        /// </summary>
        [JsonPropertyName("recipient_nceo")]
        public string RecipientCode { get; set; }

        /// <summary>
        /// Payment naming.
        /// </summary>
        [JsonPropertyName("payment_naming")]
        public string PaymentNaming { get; set; }

        /// <summary>
        /// Payment amount.
        /// </summary>
        [JsonPropertyName("payment_amount")]
        public decimal PaymentAmount { get; set; }

        /// <summary>
        /// Payment destination.
        /// </summary>
        [JsonPropertyName("payment_destination")]
        public string PaymentDestination { get; set; }

        /// <summary>
        /// Document type.
        /// </summary>
        [JsonPropertyName("document_type")]
        public string DocumentType { get; set; } = "cr";

        /// <summary>
        /// Date of payment.
        /// </summary>
        [JsonPropertyName("payment_date")]
        public DateTime? PaymentDate { get; set; }

        /// <summary>
        /// Date of payment acceptance.
        /// </summary>
        [JsonPropertyName("payment_accept_date")]
        public DateTime? PaymentAcceptDate { get; set; }

        /// <summary>
        /// Privatbank reference to copy from.
        /// </summary>
        [JsonPropertyName("payment_cb_ref")]
        public string PaymentPrivatReference { get; set; }

        /// <summary>
        /// Payment reference to copy from.
        /// </summary>
        [JsonPropertyName("copy_from_ref")]
        public string PaymentCopyReference { get; set; }

        /// <summary>
        /// List of file ids to attach.
        /// </summary>
        [JsonPropertyName("attach")]
        public string Attachments { get; set; }

        /// <summary>
        /// Message to the signer.
        /// </summary>
        [JsonPropertyName("signer_msg")]
        public string SignerMessage { get; set; }

        /// <summary>
        /// Message to the cashier.
        /// </summary>
        [JsonPropertyName("odb_msg")]
        public string OperationalMessage { get; set; }

        /// <summary>
        /// Recipient bank code.
        /// </summary>
        [JsonPropertyName("recipient_ifi")]
        public string RecipientBankCode { get; set; }

        /// <summary>
        /// Recipient bank name.
        /// </summary>
        [JsonPropertyName("recipient_ifi_text")]
        public string RecipientBankName { get; set; }
    }
}