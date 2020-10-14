using System;
using System.Text.Json.Serialization;
using Ukraine.Bank.Privatbank.Converters;

namespace Ukraine.Bank.Privatbank.Data.Models
{
    public class Balance
    {
        [JsonPropertyName("acc")]
        public string Account { get; set; }
        
        [JsonPropertyName("currency")]
        public string Currency { get; set; }
        
        [JsonPropertyName("balanceIn")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal BalanceIn { get; set; }
        
        [JsonPropertyName("balanceInEq")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal BalanceInUah { get; set; }
        
        [JsonPropertyName("balanceOut")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal BalanceOut { get; set; }
        
        [JsonPropertyName("balanceOutEq")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal BalanceOutUah { get; set; }
        
        [JsonPropertyName("turnoverDebt")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal TurnoverDebt { get; set; }
        
        [JsonPropertyName("turnoverDebtEq")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal TurnoverDebtUah { get; set; }
        
        [JsonPropertyName("turnoverCred")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal TurnoverCred { get; set; }
        
        [JsonPropertyName("turnoverCredEq")]
        [JsonConverter(typeof(DecimalConverter))]
        public decimal TurnoverCredUah { get; set; }
        
        [JsonPropertyName("bgfIBrnm")]
        public string CounterpartyBranch { get; set; }
        
        [JsonPropertyName("brnm")]
        public string AccountBranch { get; set; }
        
        [JsonPropertyName("dpd")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime LastOperationDateTime { get; set; }
        
        [JsonPropertyName("nameACC")]
        public string AccountName { get; set; }
        
        [JsonPropertyName("state")]
        public string State { get; set; }
        
        [JsonPropertyName("atp")]
        public string AccountType { get; set; }
        
        [JsonPropertyName("flmn")]
        public string Location { get; set; }
        
        [JsonPropertyName("date_open_acc_reg")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime OpenAccountRegDateTime { get; set; }
        
        [JsonPropertyName("date_open_acc_sys")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime OpenAccountSysDateTime { get; set; }
        
        [JsonPropertyName("date_close_acc")]
        [JsonConverter(typeof(DateTimeConverter))]
        public DateTime CloseAccountDateTime { get; set; }
        
        [JsonPropertyName("is_final_bal")]
        public bool FinalBalance { get; set; }
    }
}