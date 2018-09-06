using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;
using XamarinLooker.Model;
using XamarinLooker.Services;
using XamarinLooker.ViewModels.Base;

namespace XamarinLooker.ViewModels
{
    public class PerformLookViewModel : ViewModelBase
    {
        private readonly ICameraService _cameraService;
        private readonly INetworkService _networkService;
        private Look _look;
        private ImageSource _imageSource;
        public ICommand TakePhotoCommand { private set; get; }

        public ImageSource ImageSource
        {
            get => _imageSource;
            set
            {
                _imageSource = value;
                RaisePropertyChanged(() => ImageSource);
            }
        }

        public PerformLookViewModel(ICameraService cameraService, INetworkService networkService)
        {
            _cameraService = cameraService;
            _networkService = networkService;

            TakePhotoCommand = new Command(async () =>
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                    {
                        //await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
                    status = results[Permission.Camera];
                }

                if (status == PermissionStatus.Granted || status == PermissionStatus.Unknown)
                {
                    var media = await _cameraService.TakePhotoAsync();

                    ImageSource = ImageSource.FromStream(() =>
                    {
                        var stream = media.GetStream();
                        media.Dispose();
                        return stream;
                    });
                }

            });
        }

        public Look Look
        {
            get => _look;
            set
            {
                _look = value;
                RaisePropertyChanged(() => Look);
            }
        }

        public string UploadUrl { get; private set; }

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Look)
            {
                Look = (Look)navigationData;
              //  UploadUrl = await _networkService.GetMediaUploadUrlAsync(Look.Id);
            }
        }
    }
}
