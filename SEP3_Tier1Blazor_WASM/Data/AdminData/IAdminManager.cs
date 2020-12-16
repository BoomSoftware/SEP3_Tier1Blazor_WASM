using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Data.AdminData
{
    /// <summary>
    /// Interface responsible for containing all methods related with managing admin's data
    /// </summary>
    public interface IAdminManager
    {
        /// <summary>
        /// Sends a request for getting users
        /// <param name="number">The given user number</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<IList<UserShortVersion>> GetUsers(int number, int offset);
        /// <summary>
        /// Sends a request for getting posts
        /// <param name="number">The given post number</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<int>> GetPosts(int number, int offset);
        /// <summary>
        /// Sends a request for getting total number of users
        /// </summary>
        Task<int> GetTotalNumberOfUsers();
    }
}