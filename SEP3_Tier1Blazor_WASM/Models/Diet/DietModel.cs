using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Diet
{
    public class DietModel : DietShortVersion
    {
        [JsonPropertyName("meals")]
        public List<MealModel> Meals { get; set; }
        
    }
}