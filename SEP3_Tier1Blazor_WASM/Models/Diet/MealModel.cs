using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Diet
{
    public class MealModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [Required]
        [JsonPropertyName("calories")]
        public int Calories { get; set; }
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}