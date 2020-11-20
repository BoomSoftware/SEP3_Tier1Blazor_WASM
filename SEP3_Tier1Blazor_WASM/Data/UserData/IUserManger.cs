using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    public interface IUserManger
    {
        Task AddNewUser(User user);
        Task RemoveUser(int id);
        Task EditUser(User editedUser);

        Task<User> GetUser(int id);

        Task<IList<User>> GetUsers(string name);

        Task Login (Login login);
    }
}