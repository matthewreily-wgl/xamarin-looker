using System.Threading.Tasks;
using IdentityModel.OidcClient;

namespace XamarinLooker.Droid
{
    public interface IAuthenticadsftionService
    {
        Task<LoginResult> AuthenticateAsync();
    }
}