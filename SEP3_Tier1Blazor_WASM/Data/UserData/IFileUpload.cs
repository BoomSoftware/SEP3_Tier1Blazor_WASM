using System.Threading.Tasks;
using BlazorInputFile;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    public interface IFileUpload
    {
        Task<byte[]> ConvertFile(IFileListEntry file);
    }
}