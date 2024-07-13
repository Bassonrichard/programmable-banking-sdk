﻿using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Auth
{
    public class Auth
    {
        [JsonPropertyName("access_token")]
        public required string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public required string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public required string ExpiresIn { get; set; }

        [JsonPropertyName("scope")]
        public required string Scope { get; set; }
    }
}
