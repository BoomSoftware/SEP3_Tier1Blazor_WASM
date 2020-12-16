using System.Text.Json.Serialization;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    /// <summary>
    /// Class for storing training with it's owner
    /// </summary>
    public class TrainingWithOwner : TrainingModel
    {
        [JsonPropertyName("owner")]
       public SearchBarUser Owner { get; set; }
    }
}