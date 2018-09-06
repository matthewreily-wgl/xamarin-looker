using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinLooker.Model;
using XamarinLooker.Services;
using XamarinLooker.ViewModels.Base;

namespace XamarinLooker.ViewModels
{
    public class PerformLookViewModel : ViewModelBase
    {
        private readonly ICameraService _cameraService;
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

        public PerformLookViewModel(ICameraService cameraService)
        {
            _cameraService = cameraService;
            TakePhotoCommand = new Command(async () =>
            {
                var media = await _cameraService.TakePhotoAsync();

                ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = media.GetStream();
                    media.Dispose();
                    return stream;
                });
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

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Look)
            {
                Look = (Look)navigationData;
            }
        }
    }
}
