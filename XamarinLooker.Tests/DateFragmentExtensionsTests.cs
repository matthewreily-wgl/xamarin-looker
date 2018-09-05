using System;
using XamarinLooker.ExtensionHelpers;
using XamarinLooker.Model;
using Xunit;

namespace XamarinLooker.Tests
{
    public class DateFragmentExtensionsTests
    {
        [Fact]
        public void ParsesGoodDateFragment()
        {
            var dateFragment = new DateFragments()
            {
                Date = "25",
                Month = "12",
                Year = "2012"
            };

            var parsedDate = dateFragment.ToDateTime();

            Assert.Equal(12, parsedDate.Month);
            Assert.Equal(25, parsedDate.Day);
            Assert.Equal(2012, parsedDate.Year);
        }

        [Fact]
        public void ParsesZeroPaddedMonthDateFragment()
        {
            var dateFragment = new DateFragments()
            {
                Date = "25",
                Month = "02",
                Year = "2012"
            };

            var parsedDate = dateFragment.ToDateTime();

            Assert.Equal(2, parsedDate.Month);
            Assert.Equal(25, parsedDate.Day);
            Assert.Equal(2012, parsedDate.Year);
        }
    }
}
