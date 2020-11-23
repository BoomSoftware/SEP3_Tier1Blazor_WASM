using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    public interface IUserManger
    {
        Task<bool> AddNewUser(User user);
        Task RemoveUser(int id);
        Task EditUser(User editedUser, UserShortVersion currentLogged);

        Task<User> GetUser(int senderId, int receiverId);

        Task<UserShortVersion> Login (Login login);

        Task ReportUser(int senderId, int receiverId);

        Task SetAvatar(byte[] avatar);

        Task SetBackgroundImage(byte[] backgroundImage);

    }
}