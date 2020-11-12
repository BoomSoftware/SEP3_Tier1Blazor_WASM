using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data
{
    public class PostManagerRest : IPostManager
    {
        public Task AddNewPost(PostData post)
        {
            throw new System.NotImplementedException();
        }

        public Task RemovePost(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditPost(int id, PostData editedPost)
        {
            throw new System.NotImplementedException();
        }

        public Task<PostData> GetPost(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<PostData>> GetUserPosts(int userId)
        {
            throw new System.NotImplementedException();
        }
    }
}