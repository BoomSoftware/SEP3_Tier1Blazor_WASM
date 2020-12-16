using System.Threading.Tasks;
using SEP3_Tier1Blazor_WASM.Models;
using SEP3_Tier1Blazor_WASM.Models.Training;

namespace SEP3_Tier1Blazor_WASM.Data.Storage
{
    /// <summary>
    /// Interface responsible for containing all methods related with managing scheduler's settings
    /// </summary>
    public interface ILocalStorage
    {
        /// <summary>
        /// Sets customize setting for a scheduler 
        /// <param name="settings">The given scheduler settings</param>
        /// </summary>
        Task SetSchedulerSetting(SchedulerSettings settings);
        /// <summary>
        /// Returns current scheduler settings 
        /// </summary>
        Task<SchedulerSettings> GetSchedulerSetting();
    }
}