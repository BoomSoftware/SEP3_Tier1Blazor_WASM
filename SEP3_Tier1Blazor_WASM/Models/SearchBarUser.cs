using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class SearchBarUser
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        
        [JsonPropertyName("fullName")]
        public string FullName { get; set; }
    }
}