using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Notification
{
    public class NotificationModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
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