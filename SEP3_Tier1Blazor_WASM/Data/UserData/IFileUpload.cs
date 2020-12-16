using System.Threading.Tasks;
using BlazorInputFile;

namespace SEP3_Tier1Blazor_WASM.Data.UserData
{
    /// <summary>
    /// Interface responsible for containing all methods related with uploading files
    /// </summary>
    public interface IFileUpload
    {
        /// <summary>
        /// Converts uploaded image to byte array
        /// </summary>
        Task<byte[]> ConvertFile(IFileListEntry file);
    }
}