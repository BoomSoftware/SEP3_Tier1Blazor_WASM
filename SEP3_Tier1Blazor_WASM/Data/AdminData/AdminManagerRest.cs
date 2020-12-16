using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Data.AdminData
{
    /// <summary>
    /// Class responsible for connecting to API and managing requests related with admin
    /// </summary>
    public class AdminManagerRest : DataManager, IAdminManager
    {
        private HttpClient httpClient;
        private string uri;

        public AdminManagerRest()
        {
            httpClient = Client;
            uri = "https://localhost:8443/admin";
        }
        
        public async Task<IList<UserShortVersion>> GetUsers(int number, int offset)
        {
            string result = await httpClient.GetStringAsync($"{uri}/users?limit={number}&offset={offset}");
            if (!String.IsNullOrEmpty(result))
                return JsonSerializer.Deserialize<IList<UserShortVersion>>(result);
            return null;
        }

        public async Task<List<int>> GetPosts(int number, int offset)
        {
            string result = await httpClient.GetStringAsync($"{uri}/posts?limit={number}&offset={offset}");
            List<int> posts = JsonSerializer.Deserialize<List<int>>(result);
            return posts;
        }

        public async Task<int> GetTotalNumberOfUsers()
        {
            string result = await httpClient.GetStringAsync($"{uri}/total?model=users");
            return int.Parse(result);
        }
    }
}