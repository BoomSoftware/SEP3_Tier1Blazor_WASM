using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class User
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("email")]
        public string Email { get; set; }
        
        [JsonPropertyName("password")]
        public string Password { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("city")]
        public string City { get; set; }

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
        
        [JsonPropertyName("address")]
        public Address Address { get; set; }

        [JsonPropertyName("userStatus")] 
        public bool[] UserStatus { get; set; }

        public override string ToString()
        {
            return Id + Name + Email + Password + Avatar + ProfileBackground + LikedPostIds + PostIds +
                   Description;
        }
    }
}