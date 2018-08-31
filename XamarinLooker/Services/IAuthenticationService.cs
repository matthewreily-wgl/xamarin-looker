using System.Threading.Tasks;
using IdentityModel.OidcClient;

namespace XamarinLooker.Services
{
    public interface IAuthenticationService
    {
        Task<LoginResult> Authenticate();
    }
}