using System;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class PostShortVersion
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("owner")]
        public UserShortVersion Owner { get; set; }
        [JsonPropertyName("timeStamp")]
        public string TimeStamp { get; set; }
        [JsonPropertyName("picture")]
        public byte[] Picture { get; set; }
    }
}