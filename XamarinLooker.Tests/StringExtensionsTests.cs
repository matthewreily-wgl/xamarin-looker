using XamarinLooker.ExtensionHelpers;
using Xunit;

namespace XamarinLooker.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToDollarsHandlesZeroAmount()
        {
            var x = "0".ToDollars();
            Assert.NotEmpty(x);
            Assert.Equal("0.00", x);
        }
    }
}
