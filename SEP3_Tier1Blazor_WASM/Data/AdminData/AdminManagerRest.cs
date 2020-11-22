using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data.AdminData
{
    public class AdminManagerRest : IAdminManager
    {
        private HttpClient httpClient;
        private string uri;

        public AdminManagerRest()
        {
            httpClient = new HttpClient();
            uri = "http://localhost:8080/";
        }
        
        public async Task<IList<UserShortVersion>> GetUsers(int number)
        {
            string result = await httpClient.GetStringAsync($"users/{uri}/?????????");

            IList<UserShortVersion> users = JsonSerializer.Deserialize<IList<UserShortVersion>>(result);

            return users;
        }

        public async Task<IList<PostShortVersion>> GetPosts(int number)
        {
            string result = await httpClient.GetStringAsync($"posts/{uri}/?????????");

            IList<PostShortVersion> posts = JsonSerializer.Deserialize<IList<PostShortVersion>>(result);

            return posts;
        }

        public Task<int> GetTotalNumberOfUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetTotalNumberOfPosts()
        {
            throw new System.NotImplementedException();
        }
    }
}