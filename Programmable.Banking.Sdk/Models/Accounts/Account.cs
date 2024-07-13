using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Accounts
{
    public class Account
    {
        [JsonPropertyName("accountId")]
        public required string AccountId { get; set; }

        [JsonPropertyName("accountNumber")]
        public required string AccountNumber { get; set; }

        [JsonPropertyName("accountName")]
        public required string AccountName { get; set; }

        [JsonPropertyName("referenceName")]
        public required string ReferenceName { get; set; }

        [JsonPropertyName("productName")]
        public required string ProductName { get; set; }
    }
}
