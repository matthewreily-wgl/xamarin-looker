using System.Threading.Tasks;
using XamarinLooker.Model;

namespace XamarinLooker.Services
{
    public interface INetworkService
    {
        Task<Look[]> GetLooks();
        
        //ToDo: Need finish implementation
        Task<string> GetMediaUploadUrlAsync(string lookId);
    }
}