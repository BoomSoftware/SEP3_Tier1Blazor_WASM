using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    /// <summary>
    /// Class for storing an training
    /// </summary>
    public class TrainingModel
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [Required]
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("timeStamp")]
        public DateTime TimeStamp { get; set; }
        [JsonPropertyName("completed")]
        public bool IsCompleted { get; set; }
        [JsonPropertyName("duration")]
        [Required]
        [Range(1, 540, ErrorMessage = "Duration time must be between 1 and 540.")]
        public int DurationInMinutes { get; set; }
        [JsonPropertyName("color")]
        public string Color { get; set; }
        [JsonPropertyName("exercises")]
        public List<ExerciseModel> Exercises { get; set; }
        [JsonPropertyName("global")]
        public bool IsPublic { get; set; }
        [Required]
        [JsonPropertyName("type")] 
        public string Type { get; set; }
    }
}