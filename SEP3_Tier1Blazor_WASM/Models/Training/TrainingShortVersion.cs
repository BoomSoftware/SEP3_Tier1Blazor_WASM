using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    public class TrainingShortVersion
    {
        [JsonPropertyName("trainingId")]
        public int Id { get; set; }
        [JsonPropertyName("trainingTitle")]
        public string Title { get; set; }
    }
}