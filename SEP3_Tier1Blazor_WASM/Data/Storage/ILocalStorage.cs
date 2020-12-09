using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Models.Training;

namespace SEP3_Tier1Blazor_WASM.Data.Storage
{
    public interface ILocalStorage
    {
        Task SetSchedulerSetting(SchedulerSettings settings);
        Task<SchedulerSettings> GetSchedulerSetting();
    }
}