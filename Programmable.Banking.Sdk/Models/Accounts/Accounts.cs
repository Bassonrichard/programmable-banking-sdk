using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Accounts
{
    public class AccountList
    {
        [JsonPropertyName("accounts")]
        public List<Account> Accounts { get; set; }
    }
}
