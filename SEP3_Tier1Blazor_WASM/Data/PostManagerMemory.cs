using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data
{
    public class PostManagerMemory : IPostManager
    {
        private List<Comment> comments = new List<Comment>();
        private List<PostData> posts = new List<PostData>();
        
        private List<int> likedPosts = new List<int>();
        private List<int> ownPosts = new List<int>();
        
        private HttpClient client = new HttpClient();


        public PostManagerMemory()
        {
            ownPosts.Add(0);
            ownPosts.Add(1);
            ownPosts.Add(2);
            ownPosts.Add(3);

            likedPosts.Add(0);
            likedPosts.Add(1);

            // posts.Add(new PostData()
            // {
            //     Comments = comments,
            //     Content = "This is my first amazing post",
            //     CreationTime = DateTime.Now,
            //     Id = 0,
            //     LikeNumber = 3,
            //     Title = "1",
            //     Owner = new RegularUser()
            //     {
            //         Id = 0,
            //         FirstName = "Barry",
            //         LastName = "Allen",
            //         AccountType = "RegularUser",
            //       //  Avatar = client.GetByteArrayAsync("img/example-avatar.png").Result,
            //         Description = "My name is Barry Allen and I am the fastest man on the Earth",
            //         City = "Central City",
            //         Email = "barry.allen@flash.com",
            //         LikedPostIds = likedPosts,
            //         Password = "flash",
            //       //  ProfileBackground = client.GetByteArrayAsync("img/example-bg.png").Result,
            //         PostIds = ownPosts,
            //     }
            // });
            
            // posts.Add(new PostData()
            // {
            //     Comments = comments,
            //     Content = "This is my second amazing post",
            //     CreationTime = DateTime.Now,
            //     Id = 1,
            //     Title = "1",
            //     LikeNumber = 3,
            //     Owner = new RegularUser()
            //     {
            //         Id = 0,
            //         FirstName = "Barry",
            //         LastName = "Allen",
            //         AccountType = "RegularUser",
            //       //  Avatar = client.GetByteArrayAsync("img/example-avatar.png").Result,
            //         Description = "My name is Barry Allen and I am the fastest man on the Earth",
            //         City = "Central City",
            //         Email = "barry.allen@flash.com",
            //         LikedPostIds = likedPosts,
            //         Password = "flash",
            //       //  ProfileBackground = client.GetByteArrayAsync("img/example-bg.png").Result,
            //         PostIds = ownPosts,
            //     }
            // });
            
            // posts.Add(new PostData()
            // {
            //     Comments = comments,
            //     Content = "This is my third amazing post",
            //     CreationTime = DateTime.Now,
            //     Id = 2,
            //     Title = "1",
            //     LikeNumber = 3,
            //     Owner = new RegularUser()
            //     {
            //         Id = 0,
            //         FirstName = "Barry",
            //         LastName = "Allen",
            //         AccountType = "RegularUser",
            //        // Avatar = client.GetByteArrayAsync("img/example-avatar.png").Result,
            //         Description = "My name is Barry Allen and I am the fastest man on the Earth",
            //         City = "Central City",
            //         Email = "barry.allen@flash.com",
            //         LikedPostIds = likedPosts,
            //         Password = "flash",
            //      //   ProfileBackground = client.GetByteArrayAsync("img/example-bg.png").Result,
            //         PostIds = ownPosts,
            //     }
            // });
        }

        public async Task  AddNewPost(PostData post)
        {
            posts.Add(post);
        }

        public async Task RemovePost(int id)
        {
            var itemToRemove = posts.Single(r => r.Id == 2);
            posts.Remove(itemToRemove);
        }

        public Task EditPost(int id, PostData editedPost)
        {
            throw new System.NotImplementedException();
        }

        public async Task<PostData> GetPost(int id)
        {
            return posts.Find(p => p.Id == id);
        }

        public async Task<List<PostData>> GetUserPosts(int userId)
        {
            return posts.FindAll(p => p.Owner.Id == userId);
        }
        
        public static byte[] ConvertImageToByteArray(string imagePath)
        {
            byte[] imageByteArray = null;
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            using (BinaryReader reader = new BinaryReader(fileStream))
            {
                imageByteArray = new byte[reader.BaseStream.Length];
                for (int i = 0; i<= reader.BaseStream.Length; i++)
                    imageByteArray[i] = reader.ReadByte();
            }
            return imageByteArray;
        }
    }
}