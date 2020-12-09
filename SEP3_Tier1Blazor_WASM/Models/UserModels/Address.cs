using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.UserModels
{
    public class Address
    {
        [Required]
        [JsonPropertyName("street")]
        public string Street { get; set; }
        
        [Required]
        [JsonPropertyName("number")]
        public string Number { get; set; }
    }
}