﻿using System.Text.Json.Serialization;

 namespace SEP3_Tier1Blazor_WASM.Models
{
    public class Address
    {
        [JsonPropertyName("street")]
        public string Street { get; set; }
        
        [JsonPropertyName("number")]
        public string Number { get; set; }
        
        [JsonPropertyName("city")]
        public string City { get; set; }
        
        [JsonPropertyName("postalCode")]
        public string PostalCode { get; set; }
    }
}