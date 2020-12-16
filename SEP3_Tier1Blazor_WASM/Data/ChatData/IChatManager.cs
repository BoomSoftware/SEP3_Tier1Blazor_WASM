using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.Chat;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Data.ChatData
{
    /// <summary>
    /// Interface responsible for containing all methods related with managing chat's data
    /// </summary>
    public interface IChatManager 
    {
        /// <summary>
        /// Sends a request for getting all conversations for a user
        /// <param name="userId">The given user id</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<UserSVWithMessage>> GetUsersFromConversations(int userId, int offset);
        /// <summary>
        /// Sends a request for getting conversation with a given user
        /// <param name="firstUserId">The given first id</param>
        /// <param name="secondUserId">The given second id</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<MessageModel>> GetConversationWithUser(int firstUserId, int secondUserId, int offset);
    }
}