using System;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Models
{
    public class UserAction
    {
        public int senderId { get; set; }
        public int receiverId { get; set; }
        public UserActionTypes actionType { get; set; }
        public Object value { get; set; }
    }
}