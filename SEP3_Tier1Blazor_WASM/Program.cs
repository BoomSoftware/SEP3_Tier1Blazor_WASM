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
using SEP3_Tier1Blazor_WASM.Data.ChatData;
using SEP3_Tier1Blazor_WASM.Data.DietData;
using SEP3_Tier1Blazor_WASM.Data.PostingData;
using SEP3_Tier1Blazor_WASM.Data.Storage;
using SEP3_Tier1Blazor_WASM.Data.TrainingData;
using SEP3_Tier1Blazor_WASM.Data.UserData;

namespace SEP3_Tier1Blazor_WASM
{
    /// <summary>
    /// The class responsible for setting all services and running the application
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main method for adding services, setting policies and starting the application
        /// </summary>
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(
                sp => new HttpClient {BaseAddress = new Uri(builder.HostEnvironment.BaseAddress)});
            builder.Services.AddScoped<IUserManger, UserManagerRest>();
            builder.Services.AddScoped<IPostManager, PostManagerRest>();
            builder.Services.AddScoped<IAdminManager, AdminManagerRest>();
            builder.Services.AddScoped<ITrainingManager, TrainingManagerRest>();
            builder.Services.AddScoped<IDietManager, DietManagerRest>();
            builder.Services.AddScoped<IChatManager, ChatManagerRest>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddSingleton<IFileUpload, IFileUploadManager>();
            builder.Services.AddSingleton<ILocalStorage, LocalStorageProvider>();
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