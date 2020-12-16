using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Models.Post;
using SEP3_Tier1Blazor_WASM.Models.UserModels;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Data.PostingData
{
    /// <summary>
    /// Interface responsible for containing all methods related with managing post
    /// </summary>
    public interface IPostManager
    {
        /// <summary>
        /// Sends a request for adding post
        /// <param name="post">The given post</param>
        /// </summary>
        Task<int> AddNewPost(PostShortVersion post);
        /// <summary>
        /// Sends a request for removing post
        /// <param name="id">The given post id</param>
        /// </summary>
        Task RemovePost(int id);
        /// <summary>
        /// Sends a request for editing post
        /// <param name="postShortVersion">The given post</param>
        /// </summary>
        Task EditPost(PostShortVersion postShortVersion);
        /// <summary>
        /// Sends a request for getting post by id
        /// <param name="postId">The given post id</param>
        /// <param name="userId">The given user id</param>
        /// </summary>
        Task<PostShortVersion> GetPostById(int postId, int userId);
        /// <summary>
        /// Sends a request for adding a comment into a post
        /// <param name="postId">The given post id</param>
        /// <param name="comment">The given comment</param>
        /// </summary>
        Task<int> AddCommentToPost(int postId, Comment comment);
        /// <summary>
        /// Sends a request for removing a comment from a post
        /// <param name="postId">The given post id</param>
        /// </summary>
        Task RemoveCommentFromPost(int postId);
        /// <summary>
        /// Sends a request for getting post created by user
        /// <param name="userId">The given user id</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<int>> GetPostByUser(int userId, int offset);
        /// <summary>
        /// Sends a request for getting post reactions
        /// <param name="postId">The given post id</param>
        /// </summary>
        Task<List<UserShortVersion>> GetPostReactions(int postId);
        /// <summary>
        /// Sends a request for getting post comments
        /// <param name="postId">The given post id</param>
        /// </summary>
        Task<List<Comment>> GetPostComments(int postId);
        /// <summary>
        /// Sends a request for interacting with a post
        /// <param name="postId">The id of post</param>
        /// <param name="userId">The id of user</param>
        /// <param name="actionType">The given actionType</param>
        /// <param name="value">The given value</param>
        /// </summary>
        Task InteractWithPost(int postId, int userId, UserActionTypes actionType, bool value);
        /// <summary>
        /// Sends a request for getting post for user
        /// <param name="userId">The given user id</param>
        /// <param name="offset">The given offset</param>
        /// </summary>
        Task<List<int>> GetPostsForUser(int userId, int offset);


    }
}