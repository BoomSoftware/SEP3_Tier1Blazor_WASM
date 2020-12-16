using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Models.UserModels;

namespace SEP3_Tier1Blazor_WASM.Shared
{
    public static class StaticFunctions
    {
        /// <summary>
        /// Creates and returns a uri required to open a user profile view base on a given name
        /// <param name="name">The given name</param>
        /// </summary>
        public static string GetUserUri(string name)
        {
            StringBuilder stringBuilder = new StringBuilder(name);

            if (name.Contains(" "))
            {
                for (int i = 0; i < stringBuilder.Length; i++)
                {
                    if (stringBuilder[i] == (char) 32)
                    {
                        stringBuilder[i] = '.';
                    }
                }
            }

            name = stringBuilder.ToString();
            return name;
        }

        /// <summary>
        /// Returns user which is already loaded in a system
        /// <param name="state">The given authentication state</param>
        /// </summary>
        public static UserShortVersion GetLoggedUser(AuthenticationState state)
        {
            UserShortVersion user = new UserShortVersion
            {
                UserId = Int32.Parse(state.User.Claims.First(c => c.Type.Equals("Id")).Value),
                AccountType = state.User.Claims.First(c => c.Type.Equals("AccountType")).Value,
                UserFullName = state.User.Claims.First(c => c.Type.Equals("Name")).Value
            };
            
            if(!user.AccountType.Equals("Administrator"))
            {
                user.Avatar = Convert.FromBase64String(state.User.Claims.First(c => c.Type.Equals("Avatar")).Value);
            }

            return user;
        }

        /// <summary>
        /// Returns user id for a user which is already loaded in a system
        /// <param name="state">The given authentication state</param>
        /// </summary>
        public static int GetLoggedUserId(AuthenticationState state)
        {
            return Int32.Parse(state.User.Claims.First(c => c.Type.Equals("Id")).Value);
        }
        
        /// <summary>
        /// Returns an string version of a user avatar
        /// <param name="user">The given user</param>
        /// </summary>
        public static string GetUserAvatar(UserShortVersion user)
        {
            return String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(user.Avatar));
        }

        /// <summary>
        /// Returns an string version of a image in form of a byte array
        /// <param name="img">The given images</param>
        /// </summary>
        public static string GetImgFromByteArray(byte[] img)
        {
            return String.Format("data:image/gif;base64,{0}", Convert.ToBase64String(img));
        }
    }
}