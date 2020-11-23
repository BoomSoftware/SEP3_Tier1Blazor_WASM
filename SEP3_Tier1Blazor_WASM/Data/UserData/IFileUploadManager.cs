using System.IO;
using System.Threading.Tasks;
using BlazorInputFile;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    public class IFileUploadManager : IFileUpload
    {

        public async Task<byte[]> ConvertFile(IFileListEntry file)
        {
            using (var ms = new MemoryStream())
            {
                await file.Data.CopyToAsync(ms);
                return ms.ToArray();
            }
            
        }
    }
}