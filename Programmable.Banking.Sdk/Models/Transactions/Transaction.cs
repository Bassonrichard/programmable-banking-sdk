using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Transactions
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
        public required string PostedOrder { get; set; }

        [JsonPropertyName("postingDate")]
        public required string PostingDate { get; set; }

        [JsonPropertyName("valueDate")]
        public required string ValueDate { get; set; }

        [JsonPropertyName("actionDate")]
        public required string ActionDate { get; set; }

        [JsonPropertyName("transactionDate")]
        public required string TransactionDate { get; set; }

        [JsonPropertyName("amount")]
        public required string Amount { get; set; }
    }
}
