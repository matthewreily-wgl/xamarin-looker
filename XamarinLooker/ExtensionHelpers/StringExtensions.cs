using System.Globalization;
using System.Text;

namespace XamarinLooker.ExtensionHelpers
{
    public static class StringExtensions
    {
        public static string ToDollars(this string amount)
        {
            return (int.Parse(amount) / 100m).ToString("N2");
        }
    }
}