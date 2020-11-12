using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data
{
    public interface IUserManger
    {
        Task AddNewUser(User user);
        Task RemoveRegularUser(int id);
        Task RemovePageOwner(int id);
        Task EditRegularUser(int id, User editedUser);
        Task EditPageOwner(int id, PageOwner editedPageOwner);

        Task<User> GetUser(int id);

        Task<IList<User>> GetUsers(string name);

        Task Login (Login login);
    }
}