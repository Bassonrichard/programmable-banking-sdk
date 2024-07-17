using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Accounts
{
    public class Transfers
    {
        [JsonPropertyName("transferList")]
        public List<Transfer> TransferList { get; set; }
    }
}
