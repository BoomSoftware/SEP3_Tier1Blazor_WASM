using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Notification;
using SEP3_Tier1Blazor_WASM.Models.UserModels;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    /// <summary>
    /// Interface responsible for containing all methods related with managing user's data
    /// </summary>
    public interface IUserManger
    {
        /// <summary>
        /// Sends a request for adding given user
        /// <param name="user">The given user</param>
        /// </summary>
        Task<bool> AddNewUser(User user);
        /// <summary>
        /// Sends a request for removing user with given id
        /// <param name="id">The given id</param>
        /// </summary>
        Task RemoveUser(int id);
        /// <summary>
        /// Sends a request for edit given user
        /// <param name="editedUser">The given user</param>
        /// <param name="currentLogged">The current logged user</param>
        /// </summary>
        Task<bool> EditUser(User editedUser, UserShortVersion currentLogged);
        /// <summary>
        /// Sends a request for getting user
        /// <param name="senderId">The id of sender request</param>
        /// <param name="receiverId">The id of receiver request</param>
        /// </summary>
        Task<User> GetUser(int senderId, int receiverId);
        /// <summary>
        /// Sends a request for getting user
        /// <param name="login">The given login credential</param>
        /// </summary>
        Task<UserShortVersion> Login (Login login);
        /// <summary>
        /// Sends a request for getting user friends
        /// <param name="senderId">The id of sender request</param>
        /// <param name="userId">The given user id</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<UserShortVersionWithStatus>> GetUserFriends(int userId,int senderId, int offset);
        /// <summary>
        /// Sends a request for interact with user
        /// <param name="senderId">The id of sender</param>
        /// <param name="receiverId">The id of receiver</param>
        /// <param name="actionType">The given actionType</param>
        /// <param name="value">The given value</param>
        /// </summary>
        Task InteractWithUser(int senderId, int receiverId, UserActionTypes actionType, object value);
        /// <summary>
        /// Sends a request for marking notification as read
        /// <param name="notificationId">The id of a notification</param>
        /// </summary>
        Task MarkNotificationAsRead(int notificationId);
        /// <summary>
        /// Sends a request for getting user's notifications
        /// <param name="userId">The given user id</param>
        /// </summary>
        Task<List<NotificationModel>> GetNotificationsForUser(int userId);
        /// <summary>
        /// Sends a request for getting gyms in a given city
        /// <param name="city">The given city name</param>
        /// </summary>
        Task<List<UserShortVersion>> GetGymsInTheCity(string city);
        /// <summary>
        /// Sends a request for getting online users
        /// <param name="userId">The given user id</param>
        /// </summary>
        Task<List<UserShortVersion>> GetOnlineUsers(int userId);
        /// <summary>
        /// Sends a request for getting user in short version
        /// <param name="userId">The given user id</param>
        /// </summary>
        Task<UserShortVersion> GetUserShortVersion(int userId);
        /// <summary>
        /// Sends a request for incrementing a user score
        /// <param name="userId">The given user id</param>
        /// <param name="scoreToAdd">The given score to add</param>
        /// </summary>
        Task IncrementScore(int userId, int scoreToAdd);
    }
}