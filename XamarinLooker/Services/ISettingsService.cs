namespace XamarinLooker.Services
{
    public interface ISettingsService
    {
        string AuthAccessToken { get; set; }
        bool UseMockData { get; set; }
        string UserId { get; set; }
    }
}