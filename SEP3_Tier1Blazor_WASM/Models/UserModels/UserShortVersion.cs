using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.UserModels
{
    public class UserShortVersion
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        
        [JsonPropertyName("userFullName")]
        public string UserFullName { get; set; }
        
        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }
        
        [JsonPropertyName("avatar")]
        public byte[] Avatar { get; set; }
    }
}