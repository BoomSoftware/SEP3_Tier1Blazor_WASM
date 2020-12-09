using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Notification;
using SEP3_Tier1Blazor_WASM.Models.UserModels;
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
        Task<List<UserShortVersionWithStatus>> GetUserFriends(int userId,int senderId, int offset);
        Task InteractWithUser(int senderId, int receiverId, UserActionTypes actionType, object value);
        Task MarkNotificationAsRead(int notificationId);
        Task<List<NotificationModel>> GetNotificationsForUser(int userId);

        Task<List<UserShortVersion>> GetGymsInTheCity(string city);
        
        Task<List<UserShortVersion>> GetOnlineUsers(int userId);

        Task<UserShortVersion> GetUserShortVersion(int userId);

        Task IncrementScore(int userId, int scoreToAdd);

    }
}