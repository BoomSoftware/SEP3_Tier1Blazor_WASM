using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Models.Post;
using SEP3_Tier1Blazor_WASM.Models.UserModels;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Data.PostingData
{
    public interface IPostManager
    {
        Task<int> AddNewPost(PostShortVersion post);
        Task RemovePost(int id);
        Task EditPost(PostShortVersion postShortVersion);
        Task<PostShortVersion> GetPostById(int postId, int userId);
        Task<int> AddCommentToPost(int postId, Comment comment);
        Task RemoveCommentFromPost(int postId);
        Task<List<int>> GetPostByUser(int userId, int offset);
        Task<List<UserShortVersion>> GetPostReactions(int postId);
        Task<List<Comment>> GetPostComments(int postId);
        Task InteractWithPost(int postId, int userId, UserActionTypes actionType, bool value);

        Task<List<int>> GetPostsForUser(int userId, int offset);


    }
}