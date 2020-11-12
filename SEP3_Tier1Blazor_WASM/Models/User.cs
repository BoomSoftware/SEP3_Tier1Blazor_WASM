using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public abstract class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("accountType")]
        public string AccountType { get; set; }
        
        [JsonPropertyName("description")]
        public string Description { get; set; }
        
        [JsonPropertyName("posts")]
        public List<int> PostIds { get; set; } 
        
        [JsonPropertyName("likedPosts")]
        public List<int> LikedPostIds { get; set;}
        
        [JsonPropertyName("avatar")]
        public byte[] Avatar { get; set; }
        
        [JsonPropertyName("profileBackground")]
        public byte[] ProfileBackground { get; set; }


        public override string ToString()
        {
            return Id + Name + Email + Password + AccountType + Avatar + ProfileBackground + LikedPostIds + PostIds +
                   Description;
        }
    }
}