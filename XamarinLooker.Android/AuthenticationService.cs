using IdentityModel.OidcClient;
using Xamarin.Forms;
using Auth0.OidcClient;
using XamarinLooker.Model;
using System.Threading.Tasks;
using XamarinLooker.Services;

[assembly: Dependency(typeof(XamarinLooker.Droid.AuthenticationService))]

namespace XamarinLooker.Droid
{
    public class AuthenticationService :  IAuthenticationService
    {
        private readonly IAuth0Client _auth0Client;

        public AuthenticationService()
        {
            _auth0Client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = AuthenticationConfig.Domain,
                ClientId = AuthenticationConfig.ClientId,

            });
        }
        public async Task<LoginResult> AuthenticateAsync()
        {
            var options = new { audience = "https://apidev.wegolook.com", responseType = "id_token token" };

            var results = await _auth0Client.LoginAsync(options);

            //var x = results.Result.IsError;

            return results;
        }
    }
}


