using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models
{
    public class Links
    {
        [JsonPropertyName("self")]
        public required string Self { get; set; }
    }
}
