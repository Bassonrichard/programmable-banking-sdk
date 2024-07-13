using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Beneficiaries
{
    public class Beneficiary
    {
        [JsonPropertyName("beneficiaryId")]
        public required string BeneficiaryId { get; set; }

        [JsonPropertyName("accountNumber")]
        public required string AccountNumber { get; set; }

        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [JsonPropertyName("bank")]
        public required string Bank { get; set; }

        [JsonPropertyName("beneficiaryName")]
        public required string BeneficiaryName { get; set; }

        [JsonPropertyName("lastPaymentAmount")]
        public required string LastPaymentAmount { get; set; }

        [JsonPropertyName("lastPaymentDate")]
        public required string LastPaymentDate { get; set; }

        [JsonPropertyName("cellNo")]
        public string? cellNo { get; set; }

        [JsonPropertyName("emailAddress")]
        public string? emailAddress { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }

        [JsonPropertyName("referenceAccountNumber")]
        public required string ReferenceAccountNumber { get; set; }

        [JsonPropertyName("referenceName")]
        public required string ReferenceName { get; set; }

        [JsonPropertyName("categoryId")]
        public required string CategoryId { get; set; }

        [JsonPropertyName("profileId")]
        public required string ProfileId { get; set; }
    }
}
