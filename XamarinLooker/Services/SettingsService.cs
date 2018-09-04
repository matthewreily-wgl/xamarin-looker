namespace XamarinLooker.Services
{
    public class SettingsService : ISettingsService
    {
        public string AuthAccessToken { get; set; }
        public bool UseMockData { get; set; }
        public string UserId { get; set; }
    }
}