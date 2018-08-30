namespace XamarinLooker.Shared
{
    public class AuthenticationViewModel : ViewModelBase
    {
        private bool _isAuthenticated;
        private IAuthenticationService _authenticationService;

        public AuthenticationViewModel(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
            _authenticationService.Authenticate();
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
    }
}


