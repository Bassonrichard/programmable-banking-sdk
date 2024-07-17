using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Accounts
{
    public class TransferResponse
    {
        [JsonPropertyName("paymentReferenceNumber")]
        public string PaymentReferenceNumber { get; set; }

        [JsonPropertyName("paymentDate")]
        public string PaymentDate { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("beneficiaryName")]
        public string BeneficiaryName { get; set; }

        [JsonPropertyName("beneficiaryAccountId")]
        public string BeneficiaryAccountId { get; set; }

        [JsonPropertyName("authorisationRequired")]
        public bool AuthorisationRequired { get; set; }
    }
}
