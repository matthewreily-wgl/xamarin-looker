using System;
using XamarinLooker.Shared;
using Xunit;
using Moq;

namespace XamarinLooker.Tests
{
    public class AuthenticationViewModelTests
    {
        [Fact]
        public void CallAuthenticateWhenIsAuthenticatedFalse()
        {

            var authenticationService = new Mock<IAuthenticationService>();
            var vm = new AuthenticationViewModel(authenticationService.Object);

            authenticationService.Verify(a => a.Authenticate(), Times.Once());
        }
    }
}
