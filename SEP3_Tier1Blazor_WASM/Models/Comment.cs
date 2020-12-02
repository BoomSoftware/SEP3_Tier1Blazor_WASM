using System;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class Comment
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("owner")]
        public UserShortVersion Owner { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("timeStamp")]
        public DateTime CreationTime { get; set;}
    }
}