using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using SEP3_Tier1Blazor_WASM.Models.Training;

namespace SEP3_Tier1Blazor_WASM.Data.Storage
{
    /// <summary>
    /// Class responsible for managing scheduler's settings
    /// </summary>
    public class LocalStorageProvider : ILocalStorage
    {
        private readonly IJSRuntime jsRuntime;
        
        public LocalStorageProvider(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }
        
        public async Task SetSchedulerSetting(SchedulerSettings settings)
        {
            string serializedSettings = JsonSerializer.Serialize(settings);
            await jsRuntime.InvokeAsync<string>(
                "localStorage.setItem", 
                "scheduler", 
                serializedSettings);
        }

        public async Task<SchedulerSettings> GetSchedulerSetting()
        {
            string settingsJson = await jsRuntime.InvokeAsync<string>(
                "localStorage.getItem", 
                "scheduler");
            SchedulerSettings settings = JsonSerializer.Deserialize<SchedulerSettings>(settingsJson);
            return settings;
        }
    }
}