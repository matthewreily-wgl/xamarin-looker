
using Xamarin.Forms;
using XamarinLooker.Services;
using XamarinLooker.ViewModels.Base;

namespace XamarinLooker.ViewModels
{
    public class AuthenticateViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private IAuthenticationService _authenticationService;
        private bool _isAuthenticated;

        public AuthenticateViewModel(ISettingsService settingsService)
        {
            _authenticationService = DependencyService.Get<IAuthenticationService>();
            _settingsService = settingsService;
            if(string.IsNullOrEmpty(_settingsService.AuthAccessToken))
            {
                Login();
            }
        }

        public bool IsAuthenticated
        {
            get
            {
                return _isAuthenticated;
            }

            set
            {
                _isAuthenticated = value;
                RaisePropertyChanged(() => IsAuthenticated);
            }
        }
        public async void Login()
        {
            var result = await _authenticationService.Authenticate();

            if (!result.IsError)
            {
                IsAuthenticated = true;
                _settingsService.AuthAccessToken = result.AccessToken;
                await NavigationService.NavigateToAsync<MainViewModel>();
            }
        }
    }
}


