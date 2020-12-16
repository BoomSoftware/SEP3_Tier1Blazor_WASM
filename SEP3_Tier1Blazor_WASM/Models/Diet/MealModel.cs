using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Diet
{
    /// <summary>
    /// Class for storing meal
    /// </summary>
    public class MealModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        
        [Required]
        [Range(1, 10000, ErrorMessage = "Calories field must be between 1 and 10000.")]
        [JsonPropertyName("calories")]
        public int Calories { get; set; }
        [Required]
        [JsonPropertyName("description")]
        public string Description { get; set; }
    }
}