using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Accounts
{
    public class Balance
    {
        [JsonPropertyName("accountId")]
        public required string AccountId { get; set; }

        [JsonPropertyName("currentBalance")]
        public decimal CurrentBalance { get; set; }

        [JsonPropertyName("availableBalance")]
        public decimal AvailableBalance { get; set; }

        [JsonPropertyName("currency")]
        public required string Currency { get; set; }
    }
}
