
using System.Threading.Tasks;
using Auth0.OidcClient;
using IdentityModel.OidcClient;
using Xamarin.Forms;
using XamarinLooker.iOS;
using XamarinLooker.Model;
using XamarinLooker.Services;

[assembly: Dependency(typeof(AuthenticationService))]
namespace XamarinLooker.iOS
{
    public class AuthenticationService : IAuthenticationService
    {
        private Auth0Client _auth0Client;

        public AuthenticationService()
        {
            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = AuthenticationConfig.Domain,
                ClientId = AuthenticationConfig.ClientId
            });
        }

        public Task<LoginResult> AuthenticateAsync()
        {
            var options = new { audience = "https://apidev.wegolook.com", responseType = "id_token token" };
            return _auth0Client.LoginAsync(options);
        }
    }
}
