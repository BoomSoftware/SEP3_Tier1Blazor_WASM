using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data.PostingData
{
    public interface IPostManager
    {
        Task AddNewPost(PostShortVersion post);
        Task RemovePost(int id);
        Task EditPost(PostData editedPost);
        Task<PostData> GetPost(UserShortVersion userShortVersion);
        Task<List<PostData>> GetUserPosts(int userId);
        Task AddCommentToPost(Comment comment, int postId);
        Task RemoveCommentFromPost(int commentId, int postId);

    }
}