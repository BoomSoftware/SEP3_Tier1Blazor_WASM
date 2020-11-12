using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data
{
    public class UserManagerMemory : IUserManger
    {
        private List<User> users = new List<User>();
        private List<int> likedPosts = new List<int>();
        private List<int> ownPosts = new List<int>();

        private HttpClient client = new HttpClient();

        public UserManagerMemory()
        {
            
            ownPosts.Add(0);
            ownPosts.Add(1);
            ownPosts.Add(2);
            ownPosts.Add(3);
            
            likedPosts.Add(0);
            likedPosts.Add(1);

            // users.Add(new RegularUser()
            // {
            //     Id = 0,
            //     FirstName = "Barry",
            //     LastName = "Allen",
            //     AccountType = "RegularUser",
            //    // Avatar = client.GetByteArrayAsync("https://static.vix.com/es/sites/default/files/styles/1x1/public/btg/series.batanga.com/files/Lo-que-vimos-en-el-final-de-la-primera-temporada-de-The-Flash-y-lo-que-se-viene-en-la-segunda.png").Result,
            //     Description = "My name is Barry Allen and I am the fastest man on the Earth",
            //     City = "Central City",
            //     Email = "barry.allen@flash.com",
            //     LikedPostIds = likedPosts,
            //     Password = "flash",
            //    // ProfileBackground = client.GetByteArrayAsync("img/example-bg.png").Result,
            //     PostIds = ownPosts
            // });
        }
        
        
        public async Task AddNewUser(User user)
        {
            users.Add(user);
        }

        public Task RemoveRegularUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task RemovePageOwner(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task EditRegularUser(int id, User editedUser)
        {
            throw new System.NotImplementedException();
        }

        public Task EditPageOwner(int id, PageOwner editedPageOwner)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> GetUser(int id)
        {
            return users.Find(u => u.Id == id);
        }

        public Task<IList<User>> GetUsers(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task Login(Login login)
        {
            throw new System.NotImplementedException();
        }
        
    }
}