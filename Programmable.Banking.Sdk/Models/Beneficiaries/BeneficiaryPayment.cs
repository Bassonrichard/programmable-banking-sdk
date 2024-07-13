using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Beneficiaries
{
    public class BeneficiaryPayment
    {
        [JsonPropertyName("beneficiaryId")]
        public required string BeneficiaryId { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("myReference")]
        public required string MyReference { get; set; }

        [JsonPropertyName("theirReference")]
        public required string TheirReference { get; set; }
    }
}
