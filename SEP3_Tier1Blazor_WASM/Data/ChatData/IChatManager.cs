using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Chat;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Data.ChatData
{
    public interface IChatManager
    {
        Task<List<UserSVWithMessage>> GetUsersFromConversations(int userId, int offset);
        Task<List<MessageModel>> GetConversationWithUser(int firstUserId, int secondUserId, int offset);
    }
}