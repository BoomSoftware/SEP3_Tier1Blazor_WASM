using System;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using SEP3_Tier1Blazor_WASM.Models;

namespace SEP3_Tier1Blazor_WASM.Shared
{
    public static class StaticFunctions
    {
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

        public static UserShortVersion GetLoggedUser(AuthenticationState state)
        {
            return new UserShortVersion
            {
                UserId = Int32.Parse(state.User.Claims.First(c => c.Type.Equals("Id")).Value),
                AccountType = state.User.Claims.First(c => c.Type.Equals("AccountType")).Value,
                Avatar = Convert.FromBase64String(state.User.Claims.First(c => c.Type.Equals("Avatar")).Value),
                UserFullName = state.User.Claims.First(c => c.Type.Equals("Name")).Value
            };
        }

        public static int GetLoggedUserId(AuthenticationState state)
        {
            return Int32.Parse(state.User.Claims.First(c => c.Type.Equals("Id")).Value);
        }
    }
}