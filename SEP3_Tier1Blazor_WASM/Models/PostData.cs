using System;
using System.Collections.Generic;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class PostData
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public UserShortVersion Owner { get; set;}
        public string Content { get; set;}
        public DateTime CreationTime { get; set;}
        public List<Comment> Comments { get; set;}
        public byte[] Picture { get; set; }
        public int LikeNumber { get; set;}
    }
}