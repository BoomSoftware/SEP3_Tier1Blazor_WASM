using System;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class TrainingModel
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("timeStamp")]
        public DateTime TimeStamp { get; set; }
        [JsonPropertyName("isCompleted")]
        public bool IsCompleted { get; set; }
        [JsonPropertyName("durationInMinutes")]
        public int DurationInMinutes { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
    }
}