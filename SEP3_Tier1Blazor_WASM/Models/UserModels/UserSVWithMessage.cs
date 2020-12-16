using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Models.Chat;

namespace SEP3_Tier1Blazor_WASM.Models.UserModels
{
    /// <summary>
    /// Class for storing user short version with message
    /// </summary>
    public class UserSVWithMessage : UserShortVersion
    {
        [JsonPropertyName("message")]
        public MessageModel LastMessage { get; set; }
        
        [JsonIgnore]
        public bool MessageUnread { get; set; }
    }
}