using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Transactions
{
    public class TransactionList
    {
        [JsonPropertyName("transactions")]
        public List<Transaction> Transactions { get; set; }
    }
}
