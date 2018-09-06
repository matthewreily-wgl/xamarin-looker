using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
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
                NavigationService.NavigateToAsync<PerformLookViewModel>(LookDetails);
            });
        }
        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Look)
            {
                IsBusy = true;
                LookDetails = (Look)navigationData;
                //Android requires an api key to use the Google Maps Api. Link to directions below
                //https://docs.microsoft.com/en-us/xamarin/android/platform/maps-and-location/maps/obtaining-a-google-maps-api-key?tabs=vswin


                if (LookDetails.Forms.Client.DocumentLocation != null)
                {
                    await CreateMapAsync(LookDetails.Forms.Client.DocumentLocation.Coordinates.Points);
                }
                else if (LookDetails.Forms.Client.Location != null)
                {
                    await CreateMapAsync(LookDetails.Forms.Client.Location.Coordinates.Points);
                }
                IsBusy = false;
            }
        }

        private async Task CreateMapAsync(string[] points)
        {
            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        //await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    var position = new Position(double.Parse(points[1]), double.Parse(points[0]));
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
            catch (Exception ex)
            {
                //...
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