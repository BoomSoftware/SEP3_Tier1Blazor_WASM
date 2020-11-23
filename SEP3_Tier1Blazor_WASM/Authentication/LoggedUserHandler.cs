using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SEP3_Tier1Blazor_WASM.Authentication
{
    public class LoggedUserHandler : AuthorizationHandler<LoggedUserRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, LoggedUserRequirement requirement)
        {
            if (!context.User.HasClaim(claim => claim.Type == "Id"))
            {
                return Task.CompletedTask;
            }

            var userId = context.User.FindFirst(c => c.Type == "Id").Value;

            // if (int.Parse(userId) == requirement.ProfileId)
            // {
            //     return context.Succeed(requirement);
            // }
            
            return Task.CompletedTask;
        }
    }
}