using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
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

            await builder.Build().RunAsync();
        }
    }
}