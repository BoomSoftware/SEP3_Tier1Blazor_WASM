using System;

namespace SEP3_Tier1Blazor_WASM.Shared
{
    [Flags]
    public enum UserActionTypes
    {
        USER_REPORT,
        USER_FRIEND_REQUEST_SEND,
        USER_FRIEND_REQUEST_RESPONSE,
        USER_FRIEND_REMOVE,
        USER_SHARE_TRAININGS,
        USER_SHARE_DIETS,
        USER_FOLLOW_PAGE,
        USER_RATE_PAGE,
        POST_LIKE,
        POST_REPORT,
        MESSAGE_CREATE,
    }
}