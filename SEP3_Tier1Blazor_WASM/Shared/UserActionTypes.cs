using System;

namespace SEP3_Tier1Blazor_WASM.Shared
{
    [Flags]
    public enum UserActionTypes
    {
        USER_REGISTER,
        USER_LOGIN,
        USER_GET_BY_ID,
        USER_EDIT,
        USER_DELETE,
        USER_REPORT,
        USER_FRIEND_REQUEST_SEND,
        USER_FRIEND_REQUEST_RESPONSE,
        USER_FRIEND_REMOVE,
        USER_SHARE_TRAININGS,
        USER_SHARE_DIETS,
        USER_FOLLOW_PAGE,
        USER_RATE_PAGE,
        POST_CREATE,
        POST_GET_BY_ID,
        POST_GET_FOR_USER,
        POST_GET_BY_USER,
        POST_UPDATE,
        POST_DELETE,
        POST_LIKE,
        POST_REPORT,
        ADMIN_GET_USERS,
        ADMIN_GET_POSTS,
        HAS_IMAGES,
        
        MESSAGE_CREATE,
        MESSAGE_DELETE,
        MESSAGE_GET_LATEST,
        MESSAGE_GET_CONVERSATION,
    }
}