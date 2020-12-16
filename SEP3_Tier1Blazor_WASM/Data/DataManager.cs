using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace SEP3_Tier1Blazor_WASM.Data
{
    /// <summary>
    /// Abstract class of all data services
    /// </summary>
    public abstract class DataManager
    { 
        public HttpClient Client { get; } = new HttpClient();

        /// <summary>
        /// Prepares an object for sending to the API
        /// </summary>
        public StringContent PrepareObjectForRequest(object body)
        {
            string serializedBody = JsonSerializer.Serialize(body);
            return new StringContent(
                serializedBody, 
                Encoding.UTF8, 
                "Application/json");
        }
    }
}