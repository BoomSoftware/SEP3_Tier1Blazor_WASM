using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    public class ExerciseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}