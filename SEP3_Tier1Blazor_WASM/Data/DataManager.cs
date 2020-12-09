using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace SEP3_Tier1Blazor_WASM.Data
{
    public abstract class DataManager
    { 
        public HttpClient Client { get; set; } = new HttpClient();

        public StringContent PrepareObjectForRequest(object body)
        {
            string serializedBody = JsonSerializer.Serialize(body);
            return new StringContent(serializedBody, Encoding.UTF8, "Application/json");
        }
    }
}