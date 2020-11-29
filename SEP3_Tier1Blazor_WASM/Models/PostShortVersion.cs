using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class PostShortVersion
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("owner")]
        public UserShortVersion Owner { get; set;}
        [JsonPropertyName("content")]
        public string Content { get; set;}
        [JsonPropertyName("timeStamp")]
        public DateTime CreationTime { get; set;}
        [JsonPropertyName("picture")]
        public byte[] Picture { get; set; }
        [JsonPropertyName("numberOfLikes")]
        public int LikeNumber { get; set;}
        [JsonPropertyName("numberOfComments")]
        public int CommentNumber { get; set; }
        [JsonPropertyName("hasImage")]
        public bool HasImage { get; set; }
    }
}