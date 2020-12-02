using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Shared;

namespace SEP3_Tier1Blazor_WASM.Data.PostingData
{
    public class PostManagerRest : DataManager, IPostManager
    {
        
        private HttpClient client;
        private string uri;
        
        public PostManagerRest()
        {
            client = Client;
            uri = "http://localhost:8080/posts";
        }
        
        public async Task<int> AddNewPost(PostShortVersion post)
        {
            string postSerialized = JsonSerializer.Serialize(post);
            StringContent content = new StringContent(
                postSerialized,
                Encoding.UTF8,
                "Application/json"
            );
            HttpResponseMessage response = await client.PostAsync(uri, content);
            return int.Parse(await response.Content.ReadAsStringAsync());
        }

        public async Task RemovePost(int id)
        {
            await client.DeleteAsync($"{uri}/{id}");
        }

        public async Task EditPost(PostShortVersion postShortVersion)
        {
            string postSerialized = JsonSerializer.Serialize(postShortVersion);
            StringContent content = new StringContent(
                postSerialized,
                Encoding.UTF8,
                "Application/json"
                );
            await client.PutAsync($"{uri}/{postShortVersion.Id}", content);
        }

        public async Task<PostShortVersion> GetPostById(int postId, int userId)
        { 
            HttpResponseMessage result = await client.GetAsync($"{uri}?postId={postId}&userId={userId}");
            
            string responseString = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PostShortVersion>(responseString);
        }

        public async Task<int> AddCommentToPost(int postId, Comment comment)
        {
            string commentSerialized = JsonSerializer.Serialize(comment);
            StringContent content = new StringContent(
                commentSerialized,
                Encoding.UTF8,
                "Application/json"
                );

           HttpResponseMessage response =  await client.PostAsync($"{uri}/{postId}", content);
           return int.Parse(await response.Content.ReadAsStringAsync());

        }

        public async Task RemoveCommentFromPost(int commentId)
        {
            await client.DeleteAsync($"{uri}/comments/{commentId}");
        }

        public async Task<List<int>> GetPostByUser(int userId, int offset)
        {
            HttpResponseMessage result = await client.GetAsync($"{uri}/profile?byId={userId}&offset={offset}");

            string temp = await result.Content.ReadAsStringAsync();
            Console.WriteLine("FFFFFFFFFFFFFFFFFFFFFFFFFF" + temp);
            if (!string.IsNullOrEmpty(temp))
            {
                string content = await result.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<List<int>>(content);
            }
                
            return null;
        }

        public async Task<List<UserShortVersion>> GetPostReactions(int postId)
        {
            return JsonSerializer.Deserialize<List<UserShortVersion>>(await client.GetStringAsync($"{uri}/{postId}/likes"));
        }

        public async Task<List<Comment>> GetPostComments(int postId)
        {
            return JsonSerializer.Deserialize<List<Comment>>(await client.GetStringAsync($"{uri}/{postId}/comments"));
        }

        public async Task InteractWithPost(int postId, int userId, UserActionTypes actionType, bool value)
        {
            PostAction postAction = new PostAction
            {
                PostId = postId,
                UserId = userId,
                Value = value,
                ActionType = actionType.ToString()
            };

            string actionSerialize = JsonSerializer.Serialize(postAction);
            StringContent content = new StringContent(
                actionSerialize,
                Encoding.UTF8,
                "Application/json"
                );

            await client.PostAsync($"{uri}/actions", content);


        }

        public async Task<List<int>> GetPostsForUser(int userId, int offset)
        {
            HttpResponseMessage response = await client.GetAsync($"{uri}/wall?forId={userId}&offset={offset}");
            string temp = await response.Content.ReadAsStringAsync();
            if (!string.IsNullOrEmpty(temp))
            {
                return JsonSerializer.Deserialize<List<int>>(temp);
            }
            return null;
        }
    }
}