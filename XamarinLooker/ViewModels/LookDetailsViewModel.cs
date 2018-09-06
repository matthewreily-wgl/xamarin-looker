using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using XamarinLooker.Model;
using XamarinLooker.ViewModels.Base;

namespace XamarinLooker.ViewModels
{
    public class LookDetailsViewModel : ViewModelBase
    {
        private Map _map;
        private Look _look;
        public ICommand StartLookCommand { private set; get; }
        public LookDetailsViewModel()
        {
            StartLookCommand = new Command(() =>
            {
                NavigationService.NavigateToAsync<PerformLookViewModel>();
            });
        }
        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Look)
            {
                IsBusy = true;
                LookDetails = (Look)navigationData;
                //ToDo need to get a key for android
                //https://docs.microsoft.com/en-us/xamarin/android/platform/maps-and-location/maps/obtaining-a-google-maps-api-key?tabs=vswin

                if (LookDetails.Forms.Client.DocumentLocation != null)
                {
                    var position = new Position(double.Parse(LookDetails.Forms.Client.DocumentLocation.Coordinates.Points[1]), double.Parse(LookDetails.Forms.Client.DocumentLocation.Coordinates.Points[0]));
                        Map = new Map(MapSpan.FromCenterAndRadius(position, Distance.FromMiles(0.5)))
                    {
                        IsShowingUser = true,
                        HeightRequest = 100,
                        WidthRequest = 100,
                        VerticalOptions = LayoutOptions.FillAndExpand,

                    };
                    Map.Pins.Add(new Pin() { Position = position });
                }
            }
        }

        public Look LookDetails
        {
            get => _look;
            set
            {
                _look = value;
                RaisePropertyChanged(() => LookDetails);
            }
        }

        public Map Map
        {
            get
            {
                return _map;
            }

            set
            {
                _map = value;
                RaisePropertyChanged(() => Map);
            }
        }
    }
}