using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Accounts
{
    public class Transfer
    {
        [JsonPropertyName("beneficiaryAccountId")]
        public required string BeneficiaryAccountId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("myReference")]
        public string MyReference { get; set; }

        [JsonPropertyName("theirReference")]
        public string TheirReference { get; set; }
    }
}
