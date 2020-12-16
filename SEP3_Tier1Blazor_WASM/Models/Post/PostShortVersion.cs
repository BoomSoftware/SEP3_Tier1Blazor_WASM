using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Models.Post
{
    /// <summary>
    /// Class for storing post short version
    /// </summary>
    public class PostShortVersion
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("owner")]
        public UserShortVersion Owner { get; set;}
        [Required]
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
        [JsonPropertyName("postStatus")]
        public bool[] PostStatus { get; set; }
        
        [JsonIgnore]
        public List<Comment> Comments { get; set;} = new List<Comment>();
    }
}