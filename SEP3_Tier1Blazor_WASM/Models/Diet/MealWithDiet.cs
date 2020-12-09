using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Diet
{
    public class MealWithDiet : MealModel
    {
        [JsonPropertyName("dietId")]
        public int DietId { get; set; }
    }
}