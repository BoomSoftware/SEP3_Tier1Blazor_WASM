using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Models.Diet
{
    /// <summary>
    /// Class for storing diet short version with owner
    /// </summary>
    public class DietSVWithOwner : DietShortVersion
    {
        [JsonPropertyName("owner")]
        public SearchBarUser Owner { get; set; }
    }
}