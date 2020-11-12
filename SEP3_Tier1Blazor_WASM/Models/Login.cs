using System.Text.Json.Serialization;

 namespace SEP3_Tier1Blazor_WASM.Models
{
    public class Login
    {
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}