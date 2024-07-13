using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models
{
    public class Results<T> where T : class
    {
        [JsonPropertyName("result")]
        public required List<T> Result { get; set; }
    }
}
