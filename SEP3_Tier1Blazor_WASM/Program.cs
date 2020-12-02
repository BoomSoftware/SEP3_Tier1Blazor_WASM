using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SEP3_Tier1Blazor_WASM.Authentication;
using SEP3_Tier1Blazor_WASM.Data;
using SEP3_Tier1Blazor_WASM.Data.AdminData;
using SEP3_Tier1Blazor_WASM.Data.PostingData;
using SEP3_Tier1Blazor_WASM.Data.UserData;

namespace SEP3_Tier1Blazor_WASM
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            builder.Services.AddSingleton<IUserManger, UserManagerRest>();
            builder.Services.AddSingleton<IPostManager, PostManagerRest>();
            builder.Services.AddSingleton<IAdminManager, AdminManagerRest>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddSingleton<IFileUpload, IFileUploadManager>();
            builder.Services.AddAuthorizationCore(options => {

                options.AddPolicy("CurrentLogged", a => 
                    a.RequireAuthenticatedUser().RequireAssertion(context =>
                    {
                        Claim idClaim = context.User.FindFirst(claim => claim.Type.Equals("Id"));
                        Claim roleClaim = context.User.FindFirst(claim => claim.Type.Equals("AccountType"));
                        if (idClaim == null) return true;
                        return int.Parse(idClaim.Value) == (int)context.Resource && (roleClaim.Value.Equals("RegularUser") || roleClaim.Value.Equals("PageOwner"));
                    }));
                
                options.AddPolicy("CurrentLogged/Owner/Admin", a => 
                    a.RequireAuthenticatedUser().RequireAssertion(context =>
                    {
                        Claim idClaim = context.User.FindFirst(claim => claim.Type.Equals("Id"));
                        Claim roleClaim = context.User.FindFirst(claim => claim.Type.Equals("AccountType"));
                        
                        string[] ids = context.Resource.ToString().Split('.');
                        int currentLoggedId = int.Parse(ids[0]);
                        int commentOwnerId = int.Parse(ids[1]);
                        
                        if (idClaim == null || roleClaim == null) return true;
                        return (int.Parse(idClaim.Value) == currentLoggedId && (roleClaim.Value.Equals("RegularUser")) || roleClaim.Value.Equals("PageOwner") || (int.Parse(idClaim.Value) == commentOwnerId && (roleClaim.Value.Equals("RegularUser")))|| roleClaim.Value.Equals("Administrator"));
                    }));
                
                
                options.AddPolicy("Administrator", a =>a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim roleClaim = context.User.FindFirst(claim => claim.Type.Equals("AccountType"));
                    if (roleClaim == null) return true;
                    return roleClaim.Value.Equals("Administrator") ;
                }));
                
                options.AddPolicy("User", a =>a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim roleClaim = context.User.FindFirst(claim => claim.Type.Equals("AccountType"));
                    if (roleClaim == null) return true;
                    return roleClaim.Value.Equals("RegularUser") || roleClaim.Value.Equals("PageOwner") ;
                }));
                
                options.AddPolicy("RegularUser", a =>a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim roleClaim = context.User.FindFirst(claim => claim.Type.Equals("AccountType"));
                    if (roleClaim == null) return true;
                    return roleClaim.Value.Equals("RegularUser");
                }));
                options.AddPolicy("PageOwner", a =>a.RequireAuthenticatedUser().RequireAssertion(context =>
                {
                    Claim roleClaim = context.User.FindFirst(claim => claim.Type.Equals("AccountType"));
                    if (roleClaim == null) return true;
                    return roleClaim.Value.Equals("PageOwner") ;
                }));
                
                
            });

            await builder.Build().RunAsync();
        }
    }
}