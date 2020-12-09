using System;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    public class TrainingSVWithTime : TrainingShortVersion
    {
        [JsonPropertyName("timeStamp")]
        public DateTime TimeStamp { get; set; }
        [JsonPropertyName("duration")]
        public int Duration { get; set; }

    }
}