﻿using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    public interface IUserManger
    {
        Task<bool> AddNewUser(User user);
        Task RemoveUser(int id);
        Task<bool> EditUser(User editedUser, UserShortVersion currentLogged);
        Task<User> GetUser(int senderId, int receiverId);
        Task<UserShortVersion> Login (Login login);
        Task<List<UserShortVersion>> GetUserFriends(int userId,int senderId, int offset);
        Task InteractWithUser(int senderId, int receiverId, UserActionTypes actionType, bool value);
        Task MarkNotificationAsRead(int notificationId);
        Task<List<NotificationModel>> GetNotificationsForUser(int userId);

        Task<List<UserShortVersion>> GetGymsInTheCity(string city);

    }
}