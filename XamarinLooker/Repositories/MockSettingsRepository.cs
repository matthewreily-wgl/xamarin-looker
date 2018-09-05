using XamarinLooker.Model;

namespace XamarinLooker.Repositories
{
    public class MockSettingsRepository : ISettingsRepository
    {
        private Settings _settings;

        public Settings GetSettings()
        {
            return _settings ?? (_settings = new Settings {UseMockData = true});
        }
    }
}