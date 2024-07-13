using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models
{
    public class Meta
    {
        [JsonPropertyName("totalPages")]
        public int TotalPages { get; set; }
    }
}
