using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class NotificationModel
    {
        [JsonPropertyName("senderId")]
        public int SenderId { get; set; }
        [JsonPropertyName("senderName")] 
        public string SenderName { get; set; }
        [JsonPropertyName("actionType")]
        public string ActionType { get; set; }
        [JsonPropertyName("value")]
        public bool Value { get; set; }

        [JsonIgnore]
        public string Content { get; set; }
    }
}