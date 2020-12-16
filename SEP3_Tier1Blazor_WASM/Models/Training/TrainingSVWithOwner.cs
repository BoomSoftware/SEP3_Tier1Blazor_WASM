using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    /// <summary>
    /// Class for storing training short version with it's owner
    /// </summary>
    public class TrainingSVWithOwner : TrainingShortVersion
    {
        [JsonPropertyName("owner")]
        public SearchBarUser Owner { get; set; }
    }
}