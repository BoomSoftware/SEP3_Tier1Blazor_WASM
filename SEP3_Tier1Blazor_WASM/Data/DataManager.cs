using System.Net.Http;

namespace SEP3_Tier1Blazor_WASM.Data
{
    public abstract class DataManager
    { 
        public HttpClient Client { get; set; } = new HttpClient();
    }
}