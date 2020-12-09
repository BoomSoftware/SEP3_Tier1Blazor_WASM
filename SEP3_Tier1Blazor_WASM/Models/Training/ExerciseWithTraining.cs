using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    public class ExerciseWithTraining : ExerciseModel
    {
        [JsonPropertyName("trainingId")]
        public int TrainingId { get; set; }
    }
}