using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Models.Diet
{
    public class DietWithOwner : DietModel
    {
        [JsonPropertyName("owner")]
        public SearchBarUser Owner { get; set; }
    }
}