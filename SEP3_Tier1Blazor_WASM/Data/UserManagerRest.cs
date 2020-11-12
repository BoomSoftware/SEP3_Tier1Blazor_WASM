using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data
{
    public class UserManagerRest : IUserManger
    {
        public UserShortVersion CurrentLogged { get; private set; }
        private HttpClient client;
        private string uri;
        

        private IList<RegularUser> regularUsers;
        private IList<PageOwner> pageOwners;
        
        
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

        public Task RemoveRegularUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemovePageOwner(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditRegularUser(int id, User editedUser)
        {
            throw new System.NotImplementedException();
        }

        public Task EditPageOwner(int id, PageOwner editedPageOwner)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            string result = await client.GetStringAsync($"{uri}/{id}");
            Console.WriteLine(result);

            User user = null;

            if (result.Contains("RegularUser"))
            {
                user = JsonSerializer.Deserialize<RegularUser>(result);
            }

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
            if (result.IsSuccessStatusCode)
            {
                string responseString = await result.Content.ReadAsStringAsync();
                if (responseString == null || responseString.Equals(""))
                    CurrentLogged = null;
                else
                    CurrentLogged = JsonSerializer.Deserialize<UserShortVersion>(responseString);
            }
            else
            {
                CurrentLogged = null;
            }

            
        }
    }
}