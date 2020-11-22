using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    public class UserManagerRest : IUserManger
    {
        public UserShortVersion CurrentLogged { get; private set; }
        private HttpClient client;
        private string uri;
        private IList<User> users;


        public UserManagerRest()
        {
            client = new HttpClient();
            uri = "http://localhost:8080/users";
        }


        public async Task<HttpStatusCode> AddNewUser(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "Application/json"
            );
            HttpResponseMessage response = await client.PostAsync(uri, content);

            Console.WriteLine("**************** Status code add user: " + response.StatusCode);
            
            return response.StatusCode;
        }

        public async Task RemoveUser(int id)
        {
           await client.DeleteAsync($"{uri}/{id}");
        }

        public async Task<HttpStatusCode> EditUser(User editedUser)
        {
            if (editedUser.Avatar == CurrentLogged.Avatar)
                editedUser.Avatar = null;

            string userSerialized = JsonSerializer.Serialize(editedUser);
            StringContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "Application/json");

            HttpResponseMessage response = await client.PutAsync($"{uri}/{editedUser.Id}", content);
            return response.StatusCode;
        }

        public async Task<User> GetUser(int id)
        {
            
            string result = await client.GetStringAsync($"{uri}?senderId={CurrentLogged.UserId}&receiverId={id}");
            Console.WriteLine(result);
            
            User user = JsonSerializer.Deserialize<User>(result);

            return user;
        }

        public async Task Login(Login login)
        {
            string loginSerialized = JsonSerializer.Serialize(login);
            
            StringContent content = new StringContent(
                loginSerialized,
                Encoding.UTF8,
                "Application/json");
            
            HttpResponseMessage result = await client.GetAsync($"{uri}/login?email={login.Email}&password={login.Password}");

            Console.WriteLine("********************* Status code: " + result.StatusCode);
            if (result.IsSuccessStatusCode) {
                string responseString = await result.Content.ReadAsStringAsync();
                if (responseString == null || responseString.Equals(""))
                    CurrentLogged = null;
                else
                {
                    CurrentLogged = JsonSerializer.Deserialize<UserShortVersion>(responseString);
                }
                   
            }
            else {
                CurrentLogged = null;
            }
        }

        public async Task ReportUser(int id)
        {
            UserAction userAction = new UserAction()
            {
                senderId = CurrentLogged.UserId,
                receiverId = id,
                actionType = UserActionTypes.USER_REPORT
            };
            
            string idSerialized = JsonSerializer.Serialize(userAction);
            StringContent stringContent = new StringContent(
                idSerialized,
                Encoding.UTF8,
                "Application/json");
            
            await client.PostAsync($"{uri}/actions", stringContent);
        }

        public Task SetAvatar(byte[] avatar)
        {
            throw new NotImplementedException();
        }

        public Task SetBackgroundImage(byte[] backgroundImage)
        {
            throw new NotImplementedException();
        }
    }
}