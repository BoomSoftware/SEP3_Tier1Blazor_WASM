using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Models.Chat;

namespace SEP3_Tier1Blazor_WASM.Models
{
    /// <summary>
    /// Class for storing message with sender
    /// </summary>
    public class MessageWithSender : MessageModel
    {
        [JsonPropertyName("senderName")]
        public string SenderName { get; set; }
    }
}