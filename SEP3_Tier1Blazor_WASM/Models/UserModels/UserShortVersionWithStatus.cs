using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.UserModels
{
    public class UserShortVersionWithStatus : UserShortVersion
    {
        [JsonPropertyName("status")]
        public bool[] Status { get; set; }
    }
}