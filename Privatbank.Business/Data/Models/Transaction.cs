using System;
using System.Text.Json.Serialization;
using Privatbank.Business.Converters;

namespace Privatbank.Business.Data.Models
{
    /// <summary>
    /// Transaction.
    /// </summary>
    public class Transaction
    {
        /// <summary>
        /// Recipient code.
        /// </summary>
        [JsonPropertyName("AUT_MY_CRF")]
        public string RecipientCode { get; set; }

        /// <summary>
        /// recipient bank code.
        /// </summary>
        [JsonPropertyName("AUT_MY_MFO")]
        public string RecipientBankCode { get; set; }

        /// <summary>
        /// Recipient account.
        /// </summary>
        [JsonPropertyName("AUT_MY_ACC")]
        public string RecipientAccount { get; set; }

        /// <summary>
        /// Recipient name.
        /// </summary>
        [JsonPropertyName("AUT_MY_NAM")]
        public string RecipientName { get; set; }

        /// <summary>
        /// Recipient bank name.
        /// </summary>
        [JsonPropertyName("AUT_MY_MFO_NAME")]
        public string RecipientBankName { get; set; }

        /// <summary>
        /// Recipient bank city.
        /// </summary>
        [JsonPropertyName("AUT_MY_MFO_CITY")]
        public string RecipientBankCity { get; set; }

        /// <summary>
        /// Counterparty code.
        /// </summary>
        [JsonPropertyName("AUT_CNTR_CRF")]
        public string CounterpartyCode { get; set; }

        /// <summary>
        /// Counterparty bank code.
        /// </summary>
        [JsonPropertyName("AUT_CNTR_MFO")]
        public string CounterpartyBankCode { get; set; }

        /// <summary>
        /// Counterparty account.
        /// </summary>
        [JsonPropertyName("AUT_CNTR_ACC")]
        public string CounterpartyAccount { get; set; }

        /// <summary>
        /// Counterparty name.
        /// </summary>
        [JsonPropertyName("AUT_CNTR_NAM")]
        public string CounterpartyName { get; set; }

        /// <summary>
        /// Counterparty bank name.
        /// </summary>
        [JsonPropertyName("AUT_CNTR_MFO_NAME")]
        public string CounterpartyBankName { get; set; }

        /// <summary>
        /// Counterparty bank city.
        /// </summary>
        [JsonPropertyName("AUT_CNTR_MFO_CITY")]
        public string CounterpartyBankCity { get; set; }

        /// <summary>
        /// Currency.
        /// </summary>
        [JsonPropertyName("CCY")]
        public string Currency { get; set; }

        /// <summary>
        /// Is a real transaction.
        /// </summary>
        [JsonPropertyName("FL_REAL")]
        public string Real { get; set; }

        /// <summary>
        /// Status of the transaction.
        /// </summary>
        [JsonPropertyName("PR_PR")]
        public string Status { get; set; }

        /// <summary>
        /// Document type.
        /// </summary>
        [JsonPropertyName("DOC_TYP")]
        public string DocumentType { get; set; }

        /// <summary>
        /// Document number.
        /// </summary>
        [JsonPropertyName("NUM_DOC")]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// Client date.
        /// </summary>
        [JsonPropertyName("DAT_KL")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime ClientDate { get; set; }

        /// <summary>
        /// Valuation date.
        /// </summary>
        [JsonPropertyName("DAT_OD")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime ValuationDate { get; set; }

        /// <summary>
        /// Reason.
        /// </summary>
        [JsonPropertyName("OSND")]
        public string Reason { get; set; }

        /// <summary>
        /// Amount.
        /// </summary>
        [JsonPropertyName("SUM")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal Amount { get; set; }

        /// <summary>
        /// Amount in UAH.
        /// </summary>
        [JsonPropertyName("SUM_E")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal AmountUah { get; set; }

        /// <summary>
        /// Reference.
        /// </summary>
        [JsonPropertyName("REF")]
        public string Reference { get; set; }

        /// <summary>
        /// Reference number.
        /// </summary>
        [JsonPropertyName("REFN")]
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// Valuation time.
        /// </summary>
        [JsonPropertyName("TIM_P")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime ValuationTime { get; set; }

        /// <summary>
        /// Valuation date and time.
        /// </summary>
        [JsonPropertyName("DATE_TIME_DAT_OD_TIM_P")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime ValuationDateTime { get; set; }

        /// <summary>
        /// Id.
        /// </summary>
        [JsonPropertyName("ID")]
        public string Id { get; set; }

        /// <summary>
        /// Type.
        /// </summary>
        [JsonPropertyName("TRANTYPE")]
        public string Type { get; set; }

        /// <summary>
        /// Service reference.
        /// </summary>
        [JsonPropertyName("DLR")]
        public string ServiceReference { get; set; }

        /// <summary>
        /// Technical transaction id.
        /// </summary>
        [JsonPropertyName("TECHNICAL_TRANSACTION_ID")]
        public string TechnicalId { get; set; }
    }
}