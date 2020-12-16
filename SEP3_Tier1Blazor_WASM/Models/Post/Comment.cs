using System;
using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Models.Post
{
    /// <summary>
    /// Class for storing comment
    /// </summary>
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