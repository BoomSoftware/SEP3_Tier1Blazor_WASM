using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.UserModels
{
    public class Login
    {
        [Required]
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}