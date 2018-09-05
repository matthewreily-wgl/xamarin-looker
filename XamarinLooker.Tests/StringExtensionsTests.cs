using XamarinLooker.ExtensionHelpers;
using Xunit;

namespace XamarinLooker.Tests
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ToDallarsHandlesZeroAmount()
        {
            var x = "0".ToDollars();
            Assert.NotEmpty(x);
        }

    }
}
