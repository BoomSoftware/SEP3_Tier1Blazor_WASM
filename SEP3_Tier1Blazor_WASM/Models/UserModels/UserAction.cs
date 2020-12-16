using System;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.UserModels
{
    /// <summary>
    /// Class for storing user action
    /// </summary>
    public class UserAction
    {
        [JsonPropertyName("senderId")]
        public int SenderId { get; set; }
        [JsonPropertyName("receiverId")]
        public int ReceiverId { get; set; }
        [JsonPropertyName("senderName")]
        public string SenderName { get; set; }
        [JsonPropertyName("actionType")]
        public string ActionType { get; set; }
        [JsonPropertyName("value")]
        public Object Value { get; set; }
    }
}