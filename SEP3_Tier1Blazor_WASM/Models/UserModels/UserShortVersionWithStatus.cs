using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.UserModels
{
    /// <summary>
    /// Class for storing user short version with status
    /// </summary>
    public class UserShortVersionWithStatus : UserShortVersion
    {
        [JsonPropertyName("status")]
        public bool[] Status { get; set; }
    }
}