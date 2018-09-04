namespace XamarinLooker.ExtensionHelpers
{
    public static class StringExtensions
    {
        public static string ToDollars(this string amount)
        {
            return (int.Parse(amount) / 100m).ToString("C2");
        }
    }
}