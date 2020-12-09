using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Chat;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Data.ChatData
{
    public class ChatManagerRest : DataManager, IChatManager
    {
        private HttpClient client;
        private string uri;


        public ChatManagerRest()
        {
            client = Client;
            uri = "https://localhost:8443/messages";
        }


        public async Task<List<UserSVWithMessage>> GetUsersFromConversations(int userId, int offset)
        {
            string temp = await client.GetStringAsync($"{uri}/recent?userId={userId}&offset={offset}");
            if (!string.IsNullOrEmpty(temp))
                return JsonSerializer.Deserialize<List<UserSVWithMessage>>(temp);
            return null;
        }

            public async Task<List<MessageModel>> GetConversationWithUser(int firstUserId, int secondUserId, int offset)
        {
            string temp = await client.GetStringAsync($"{uri}?firstUserId={firstUserId}&secondUserId={secondUserId}&offset={offset}");
            if (!string.IsNullOrEmpty(temp))
                return JsonSerializer.Deserialize<List<MessageModel>>(temp);
            return null;
        }
        
    }
}