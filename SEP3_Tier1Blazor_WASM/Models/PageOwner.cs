using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class PageOwner : User
    {
        [JsonPropertyName("address")]
        public Address Address { get; set; }
    }
}