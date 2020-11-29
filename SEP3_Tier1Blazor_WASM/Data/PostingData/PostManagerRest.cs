using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data.PostingData
{
    public class PostManagerRest : IPostManager
    {
        
        private HttpClient client;
        private string uri;
        
        public PostManagerRest()
        {
            client = new HttpClient();
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

        public Task RemovePost(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditPost(PostData editedPost)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PostData> GetPostById(int id)
        { 
            HttpResponseMessage result = await client.GetAsync($"{uri}/{id}");
            string responseString = await result.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<PostData>(responseString);

            // List<Comment> comments = new List<Comment>();
            //
            // UserShortVersion user1 = new UserShortVersion
            // {
            //     AccountType = "RegularUser",
            //     UserFullName = "Oliver Queen",
            //     UserId = 1,
            //     Avatar = new byte[] {}
            // };
            // comments.Add(new Comment{Id = 0, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ex neque, ornare egestas dignissim ut, condimentum vel risus. Aenean eget posuere elit. Suspendisse commodo id nunc id cursus. Maecenas facilisis arcu ac tellus aliquet, et cursus purus interdum. Nunc vitae dolor vitae lectus tincidunt laoreet. Suspendisse nec egestas dolor. ", Owner = user});
            // comments.Add(new Comment{Id =1, Content = "Omg! That's crazy", Owner = user1});
            //
            //
            // return  new PostData
            // {
            //     Title = "New training available!",
            //     Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin ex neque, ornare egestas dignissim ut, condimentum vel risus. Aenean eget posuere elit. Suspendisse commodo id nunc id cursus. Maecenas facilisis arcu ac tellus aliquet, et cursus purus interdum. Nunc vitae dolor vitae lectus tincidunt laoreet. Suspendisse nec egestas dolor. ",
            //     CreationTime = DateTime.Now,
            //     LikeNumber = 34,
            //     Comments = comments,
            //     Id = 0,
            //     Owner = user
            // };
            //throw new System.NotImplementedException();
        }

        public Task<List<PostData>> GetUserPosts(int userId)
        {
            throw new System.NotImplementedException();
        }

        public Task AddCommentToPost(Comment comment, int postId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveCommentFromPost(int commentId, int postId)
        {
            throw new NotImplementedException();
        }
    }
}