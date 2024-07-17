using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Beneficiaries
{
    public class BeneficiaryPayments
    {
        [JsonPropertyName("paymentList")]
        public List<BeneficiaryPayment> PaymentList { get; set; }
    }
}
