using System;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Chat
{
    /// <summary>
    /// Class for storing message
    /// </summary>
    public class MessageModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("senderId")]
        public int SenderId { get; set; }
        [JsonPropertyName("receiverId")]
        public int ReceiverId { get; set; }
        [JsonPropertyName("content")]
        public string Content { get; set; }
        [JsonPropertyName("hasImage")]
        public bool HasImage { get; set; }
        [JsonPropertyName("picture")]
        public byte[] Picture { get; set; }
        [JsonPropertyName("timeStamp")]
        public DateTime TimeStamp { get; set; }
    }
}