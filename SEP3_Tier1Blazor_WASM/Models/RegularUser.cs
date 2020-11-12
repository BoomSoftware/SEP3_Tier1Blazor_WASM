﻿using System.Text.Json.Serialization;

 namespace SEP3_Tier1Blazor_WASM.Models
{
    public class RegularUser : User
    {
        
        [JsonPropertyName("city")]
        public string City { get; set; }
    }
}