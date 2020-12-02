using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class PostData : PostShortVersion
    {
        [JsonPropertyName("comments")] 
        public List<Comment> Comments { get; set; }

        public PostData()
        {
            if(Comments == null)
                Comments = new List<Comment>();
        }                    
    }
}