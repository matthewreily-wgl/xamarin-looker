using XamarinLooker.Model;

namespace XamarinLooker.Repositories
{
    public class InMemorySettingsRepository : ISettingsRepository
    {
        private Settings _settings;

        public Settings GetSettings()
        {
            return _settings ?? (_settings = new Settings());
        }
    }
}