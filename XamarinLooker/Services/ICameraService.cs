using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace XamarinLooker.Services
{
    public interface ICameraService
    {
        Task<MediaFile> TakePhotoAsync();
        Task<MediaFile> TakeVideoAsync();
        Task<MediaFile> PickPhotoAsync();
        Task<MediaFile> PickVideoAsync();
        
    }
}