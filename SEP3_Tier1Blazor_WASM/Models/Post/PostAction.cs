using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Post
{
    /// <summary>
    /// Class for storing post action
    /// </summary>
    public class PostAction
    {
        [JsonPropertyName("userId")]
        public int UserId { get; set; }
        [JsonPropertyName("postId")]
        public int PostId{ get; set; }
        [JsonPropertyName("actionType")]
        public string ActionType{ get; set; }
        [JsonPropertyName("value")]
        public bool Value{ get; set; }
    }
}