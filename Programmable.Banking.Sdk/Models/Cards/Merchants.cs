﻿using System.Text.Json.Serialization;

namespace Programmable.Banking.Sdk.Models.Cards
{
    public class Merchants
    {
        [JsonPropertyName("code")]
        public required string Code { get; set; }

        [JsonPropertyName("name")]
        public required string Name { get; set; }
    }
}