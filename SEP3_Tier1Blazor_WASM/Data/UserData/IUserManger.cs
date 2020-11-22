using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    public interface IUserManger
    {
        Task<HttpStatusCode> AddNewUser(User user);
        Task RemoveUser(int id);
        Task<HttpStatusCode> EditUser(User editedUser);

        Task<User> GetUser(int id);

        Task Login (Login login);

        Task ReportUser(int id);

        Task SetAvatar(byte[] avatar);

        Task SetBackgroundImage(byte[] backgroundImage);

    }
}