using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models
{
    public class Response<T> where T : class
    {
        [JsonPropertyName("data")]
        public required T Data { get; set; }

        [JsonPropertyName("links")]
        public required Links Links { get; set; }

        [JsonPropertyName("meta")]
        public required Meta Meta { get; set; }
    }
}
