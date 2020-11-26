using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class ExerciseModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}