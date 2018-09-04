namespace XamarinLooker.Services
{
    public interface ISettingsService
    {
        string AuthAccessToken { get; set; }
        bool UseMockData { get; set; }
    }

    public class SettingsService : ISettingsService
    {
        public string AuthAccessToken { get; set; }
        public bool UseMockData { get; set; }
    }
}