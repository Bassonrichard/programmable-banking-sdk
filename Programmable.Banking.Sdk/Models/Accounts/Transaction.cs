using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Accounts
{
    public class Transaction
    {
        [JsonPropertyName("accountId")]
        public required string AccountId { get; set; }

        [JsonPropertyName("type")]
        public required string Type { get; set; }

        [JsonPropertyName("transactionType")]
        public required string TransactionType { get; set; }

        [JsonPropertyName("status")]
        public required string Status { get; set; }

        [JsonPropertyName("description")]
        public required string Description { get; set; }

        [JsonPropertyName("cardNumber")]
        public required string CardNumber { get; set; }

        [JsonPropertyName("postedOrder")]
        public required int PostedOrder { get; set; }

        [JsonPropertyName("postingDate")]
        public required required string PostingDate { get; set; }

        [JsonPropertyName("valueDate")]
        public required required string valueDate { get; set; }

        [JsonPropertyName("actionDate")]
        public required required string actionDate { get; set; }

        [JsonPropertyName("transactionDate")]
        public required required string TransactionDate { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("runningBalance")]
        public decimal RunningBalance { get; set; }
    }
}
