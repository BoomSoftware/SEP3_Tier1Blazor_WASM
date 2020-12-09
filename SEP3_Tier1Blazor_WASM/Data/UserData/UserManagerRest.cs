using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Notification;
using SEP3_Tier1Blazor_WASM.Models.UserModels;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    public class UserManagerRest : DataManager, IUserManger
    {
        private HttpClient client;
        private string uri;


        public UserManagerRest()
        {
            client = Client;
            uri = "https://localhost:8443/users";
        }


        public async Task<bool> AddNewUser(User user)
        {
            HttpResponseMessage response = await client.PostAsync(uri, PrepareObjectForRequest(user));
            if (response.IsSuccessStatusCode)
                return true;
            return false;
        }

        public async Task RemoveUser(int id)
        {
           await client.DeleteAsync($"{uri}/{id}");
        }

        public async Task<bool> EditUser(User editedUser, UserShortVersion currentLogged)
        {
            if (editedUser.Avatar == currentLogged.Avatar)
                editedUser.Avatar = null;

            HttpResponseMessage response = await client.PutAsync($"{uri}/{editedUser.Id}", PrepareObjectForRequest(currentLogged));
            if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.BadRequest)
                return true;
            return false;
        }

        public async Task<User> GetUser(int senderId, int receiverId)
        {
            
            string result = await client.GetStringAsync($"{uri}?senderId={senderId}&receiverId={receiverId}");
            Console.WriteLine(result);
            
            User user = JsonSerializer.Deserialize<User>(result);

            return user;
        }

        public async Task<UserShortVersion> Login(Login login)
        {
            HttpResponseMessage result =
                await client.GetAsync($"{uri}/login?email={login.Email}&password={login.Password}");
            
            if (result.IsSuccessStatusCode)
            {
                string responseString = await result.Content.ReadAsStringAsync();
                UserShortVersion user =  JsonSerializer.Deserialize<UserShortVersion>(responseString);
                
                
                Console.WriteLine("TYPETYPETYPE"+user.AccountType);
                return user;
            }

            return null;
        }
        
        public async Task<List<UserShortVersionWithStatus>> GetUserFriends(int userId, int senderId, int offset)
        {
            return JsonSerializer.Deserialize<List<UserShortVersionWithStatus>>(await client.GetStringAsync($"{uri}/{userId}/friends?senderId={senderId}&offset={offset}"));
        }

        public async Task InteractWithUser(int senderId, int receiverId, UserActionTypes actionType, object value)
        {
            UserAction userAction = new UserAction
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                ActionType = actionType.ToString(),
                Value = value
            };

            
            await client.PostAsync($"{uri}/actions", PrepareObjectForRequest(userAction));
        }

        public async Task MarkNotificationAsRead(int notificationId)
        {
            await client.DeleteAsync($"{uri}/notifications/{notificationId}");
        }

        public async Task<List<NotificationModel>> GetNotificationsForUser(int userId)
        {
            return JsonSerializer.Deserialize<List<NotificationModel>>(await client.GetStringAsync($"{uri}/{userId}/notifications"));
        }

        public async Task<List<UserShortVersion>> GetGymsInTheCity(string city)
        {
            HttpResponseMessage result = await client.GetAsync($"{uri}/pages?city={city}");
            string temp = await result.Content.ReadAsStringAsync();
            
            if (!string.IsNullOrEmpty(temp))
            {
                return JsonSerializer.Deserialize<List<UserShortVersion>>(temp);
            }
            return null;
        }

        public async Task<List<UserShortVersion>> GetOnlineUsers(int userId)
        {
            string temp = await client.GetStringAsync($"{uri}/{userId}/online_friends");
            if (!string.IsNullOrEmpty(temp))
                return JsonSerializer.Deserialize<List<UserShortVersion>>(temp);
            return null;
        }

        public async Task<UserShortVersion> GetUserShortVersion(int userId)
        {
            return JsonSerializer.Deserialize<UserShortVersion>(await client.GetStringAsync($"{uri}/{userId}/short"));
        }

        public async Task IncrementScore(int userId, int scoreToAdd)
        {
            await client.PutAsync($"{uri}/{userId}/score?scoreToAdd={scoreToAdd}", null);
        }
    }
}