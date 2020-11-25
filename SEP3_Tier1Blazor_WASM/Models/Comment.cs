using System;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public UserShortVersion Owner { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set;}
    }
}