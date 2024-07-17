using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Accounts
{
    public class TransferResponseList
    {
        [JsonPropertyName("transferResponses")]
        public List<TransferResponse> TransferResponses { get; set; }
    }
}
