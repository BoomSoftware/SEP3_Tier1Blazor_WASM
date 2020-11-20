using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

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


        public async Task AddNewUser(User user)
        {
            string userSerialized = JsonSerializer.Serialize(user);
            StringContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "Application/json"
            );

            HttpResponseMessage response = await client.PostAsync(uri, content);
        }

        public async Task RemoveUser(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"{uri}/{id}");
        }

        public async Task EditUser(User editedUser)
        {
            string userSerialized = JsonSerializer.Serialize(editedUser);
            StringContent content = new StringContent(
                userSerialized,
                Encoding.UTF8,
                "Application/json");

            HttpResponseMessage response = await client.PutAsync($"{uri}/{editedUser.Id}", content);
        }

        public async Task<User> GetUser(int id)
        {
            string result = await client.GetStringAsync($"{uri}/{id}");
            Console.WriteLine(result);
            
            User user = JsonSerializer.Deserialize<User>(result);

            return user;
        }

        public async Task<IList<User>> GetUsers(string name)
        {
            // IList<User> tempUsers = new List<User>(); 
            // IEnumerable<RegularUser> queryU = use.Where(user => user.FirstName.Contains(name));
            // IEnumerable<PageOwner> queryP = pageOwners.Where(user => user.Name.Contains(name));
            //
            // foreach (var regular in queryU)
            // {
            //     tempUsers.Add(regular);
            // }
            //
            // foreach (var pageOwner in queryP)
            // {
            //     tempUsers.Add(pageOwner);
            // }
            //
            // return tempUsers;
            return null;
        }

        public async Task Login(Login login)
        {
            string loginSerialized = JsonSerializer.Serialize(login);
            
            StringContent content = new StringContent(
                loginSerialized,
                Encoding.UTF8,
                "Application/json");
            
            HttpResponseMessage result = await client.GetAsync($"{uri}?email={login.Email}&password={login.Password}");
            if (result.IsSuccessStatusCode) {
                string responseString = await result.Content.ReadAsStringAsync();
                if (responseString == null || responseString.Equals(""))
                    CurrentLogged = null;
                else
                    CurrentLogged = JsonSerializer.Deserialize<UserShortVersion>(responseString);
            }
            else {
                CurrentLogged = null;
            }
        }
    }
}