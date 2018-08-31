namespace XamarinLooker.Services
{
    public interface ISettingsService
    {
        string AuthAccessToken { get; set; }
    }

    public class SettingsService : ISettingsService
    {
        public string AuthAccessToken { get; set; }
    }
}