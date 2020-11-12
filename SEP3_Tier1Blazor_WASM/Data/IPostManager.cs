using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data
{
    public interface IPostManager
    {
        Task AddNewPost(PostData post);
        Task RemovePost(int id);
        Task EditPost(int id, PostData editedPost);
        Task<PostData> GetPost(int id);
        Task<List<PostData>> GetUserPosts(int userId);
        //
    }
}