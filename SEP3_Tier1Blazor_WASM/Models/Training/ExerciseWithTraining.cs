using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    /// <summary>
    /// Class for storing an exercise with trainings
    /// </summary>
    public class ExerciseWithTraining : ExerciseModel
    {
        [JsonPropertyName("trainingId")]
        public int TrainingId { get; set; }
    }
}