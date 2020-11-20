using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data.AdminData
{
    public class AdminManagerRest : IAdminManager
    {
        public Task<IList<User>> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<PostData>> GetAllPosts()
        {
            throw new System.NotImplementedException();
        }
    }
}