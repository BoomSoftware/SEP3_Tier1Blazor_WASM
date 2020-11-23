using Microsoft.AspNetCore.Authorization;

namespace SEP3_Tier1Blazor_WASM.Authentication
{
    public class LoggedUserRequirement : IAuthorizationRequirement
    {
        public int ProfileId { get; set; }
    }
}