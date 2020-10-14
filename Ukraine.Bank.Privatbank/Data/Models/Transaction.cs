using System;
using System.Text.Json.Serialization;
using Ukraine.Bank.Privatbank.Converters;

namespace Ukraine.Bank.Privatbank.Data.Models
{
    public class Transaction
    {
        [JsonPropertyName("AUT_MY_CRF")]
        public string RecipientCode { get; set; }
        
        [JsonPropertyName("AUT_MY_MFO")]
        public string RecipientBankCode { get; set; }
        
        [JsonPropertyName("AUT_MY_ACC")]
        public string RecipientAccount { get; set; }
        
        [JsonPropertyName("AUT_MY_NAM")]
        public string RecipientName { get; set; }
        
        [JsonPropertyName("AUT_MY_MFO_NAME")]
        public string RecipientBankName { get; set; }
        
        [JsonPropertyName("AUT_MY_MFO_CITY")]
        public string RecipientBankCity { get; set; }
        
        [JsonPropertyName("AUT_CNTR_CRF")]
        public string CounterpartyCode { get; set; }
        
        [JsonPropertyName("AUT_CNTR_MFO")]
        public string CounterpartyBankCode { get; set; }
        
        [JsonPropertyName("AUT_CNTR_ACC")]
        public string CounterpartyAccount { get; set; }
        
        [JsonPropertyName("AUT_CNTR_NAM")]
        public string CounterpartyName { get; set; }
        
        [JsonPropertyName("AUT_CNTR_MFO_NAME")]
        public string CounterpartyBankName { get; set; }
        
        [JsonPropertyName("AUT_CNTR_MFO_CITY")]
        public string CounterpartyBankCity { get; set; }
        
        [JsonPropertyName("CCY")]
        public string Currency { get; set; }
        
        [JsonPropertyName("FL_REAL")]
        public string Real { get; set; }
        
        [JsonPropertyName("PR_PR")]
        public string Status { get; set; }
        
        [JsonPropertyName("DOC_TYP")]
        public string DocumentType { get; set; }
        
        [JsonPropertyName("NUM_DOC")]
        public string DocumentNumber { get; set; }
        
        [JsonPropertyName("DAT_KL")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ClientDate { get; set; }
        
        [JsonPropertyName("DAT_OD")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ValuationDate { get; set; }
        
        [JsonPropertyName("OSND")]
        public string Reason { get; set; }
        
        [JsonPropertyName("SUM")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal Amount { get; set; }
        
        [JsonPropertyName("SUM_E")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal AmountUah { get; set; }
        
        [JsonPropertyName("REF")]
        public string Reference { get; set; }
        
        [JsonPropertyName("REFN")]
        public string ReferenceNumber { get; set; }
        
        [JsonPropertyName("TIM_P")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ValuationTime { get; set; }
        
        [JsonPropertyName("DATE_TIME_DAT_OD_TIM_P")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime ValuationDateTime { get; set; }
        
        [JsonPropertyName("ID")]
        public string Id { get; set; }
        
        [JsonPropertyName("TRANTYPE")]
        public string Type { get; set; }
        
        [JsonPropertyName("DLR")]
        public string ServiceReference { get; set; }
        
        [JsonPropertyName("TECHNICAL_TRANSACTION_ID")]
        public string TechnicalId { get; set; }
    }
}