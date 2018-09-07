using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinLooker.Services
{
    public class CameraService : ICameraService
    {
        public async Task<MediaFile> TakePhotoAsync()
        {
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                //DisplayAlert("No Camera", ":( No camera available.", "OK");
                return null;
            }

            return await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                Directory = "Sample",
                Name = "test.jpg"
            });
        }

        public async Task<MediaFile> TakeVideoAsync()
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
                //DisplayAlert("No Camera", ":( No camera avaialble.", "OK");
                return null;
            }

            return await CrossMedia.Current.TakeVideoAsync(new StoreVideoOptions
            {
                Name = "video.mp4",
                Directory = "DefaultVideos",
            });
        }

        public async Task<MediaFile> PickPhotoAsync()
        {
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                //DisplayAlert("Photos Not Supported", ":( Permission not granted to photos.", "OK");
                return null;
            }

            return await CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
            });
        }
        public async Task<MediaFile> PickVideoAsync()
        {
            if (!CrossMedia.Current.IsPickVideoSupported)
            {
                //DisplayAlert("Videos Not Supported", ":( Permission not granted to videos.", "OK");
                return null;
            }
            return await CrossMedia.Current.PickVideoAsync();
        }
    }
}