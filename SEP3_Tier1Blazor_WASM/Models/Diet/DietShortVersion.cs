using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Diet
{
    public class DietShortVersion
    {
        [JsonPropertyName("id")]
        [Required]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        [Required]
        public string Title { get; set; }
        [JsonPropertyName("global")]
        public bool Global { get; set; }
        [JsonPropertyName("description")]
        [Required]
        public string Description { get; set; }
    }
}