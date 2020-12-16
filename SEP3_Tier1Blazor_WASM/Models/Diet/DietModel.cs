using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Diet
{
    /// <summary>
    /// Class for storing diet short version with meals
    /// </summary>
    public class DietModel : DietShortVersion
    {
        [JsonPropertyName("meals")]
        public List<MealModel> Meals { get; set; }
        
    }
}