using System;
using System.Text.Json.Serialization;
using Privatbank.Business.Converters;

namespace Privatbank.Business.Data.Models
{
    /// <summary>
    /// Balance record.
    /// </summary>
    public class Balance
    {
        /// <summary>
        /// Account number.
        /// </summary>
        [JsonPropertyName("acc")]
        public string Account { get; set; }

        /// <summary>
        /// Currency.
        /// </summary>
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        /// <summary>
        /// Incoming balance in the currency of account.
        /// </summary>
        [JsonPropertyName("balanceIn")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal BalanceIn { get; set; }

        /// <summary>
        /// Incoming balance in UAH.
        /// </summary>
        [JsonPropertyName("balanceInEq")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal BalanceInUah { get; set; }

        /// <summary>
        /// Outgoing balance in in the currency of account.
        /// </summary>
        [JsonPropertyName("balanceOut")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal BalanceOut { get; set; }

        /// <summary>
        /// Outgoing balance in UAH.
        /// </summary>
        [JsonPropertyName("balanceOutEq")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal BalanceOutUah { get; set; }

        /// <summary>
        /// Turnover debt in the currency of account.
        /// </summary>
        [JsonPropertyName("turnoverDebt")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal TurnoverDebt { get; set; }

        /// <summary>
        /// Turnover debt in UAH.
        /// </summary>
        [JsonPropertyName("turnoverDebtEq")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal TurnoverDebtUah { get; set; }

        /// <summary>
        /// Turnover credit in the currency of account.
        /// </summary>
        [JsonPropertyName("turnoverCred")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal TurnoverCred { get; set; }

        /// <summary>
        /// Turnover credit in UAH.
        /// </summary>
        [JsonPropertyName("turnoverCredEq")]
        [JsonConverter(typeof(StringDecimalConverter))]
        public decimal TurnoverCredUah { get; set; }

        /// <summary>
        /// Counterparty branch code.
        /// </summary>
        [JsonPropertyName("bgfIBrnm")]
        public string CounterpartyBranch { get; set; }

        /// <summary>
        /// Account branch code.
        /// </summary>
        [JsonPropertyName("brnm")]
        public string AccountBranch { get; set; }

        /// <summary>
        /// Date of the last operation.
        /// </summary>
        [JsonPropertyName("dpd")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime LastOperationDateTime { get; set; }

        /// <summary>
        /// Account name.
        /// </summary>
        [JsonPropertyName("nameACC")]
        public string AccountName { get; set; }

        /// <summary>
        /// Account state.
        /// </summary>
        [JsonPropertyName("state")]
        public string State { get; set; }

        /// <summary>
        /// Account type.
        /// </summary>
        [JsonPropertyName("atp")]
        public string AccountType { get; set; }

        /// <summary>
        /// Account location.
        /// </summary>
        [JsonPropertyName("flmn")]
        public string Location { get; set; }

        /// <summary>
        /// Date of account registration.
        /// </summary>
        [JsonPropertyName("date_open_acc_reg")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime OpenAccountRegDateTime { get; set; }

        /// <summary>
        /// Date of an account registration (internal).
        /// </summary>
        [JsonPropertyName("date_open_acc_sys")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime OpenAccountSysDateTime { get; set; }

        /// <summary>
        /// Date of an account termination.
        /// </summary>
        [JsonPropertyName("date_close_acc")]
        [JsonConverter(typeof(StringDateTimeConverter))]
        public DateTime CloseAccountDateTime { get; set; }

        /// <summary>
        /// Is a final state of a balance.
        /// </summary>
        [JsonPropertyName("is_final_bal")]
        public bool FinalBalance { get; set; }
    }
}