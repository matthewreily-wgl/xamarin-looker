using XamarinLooker.Model;
using XamarinLooker.Repositories;

namespace XamarinLooker.Services
{
    public class SettingsService : ISettingsService
    {
        private readonly ISettingsRepository _repository;

        public SettingsService(ISettingsRepository repository)
        {
            _repository = repository;
        }

        public Settings GetSettings()
        {
            return _repository.GetSettings();
        }
    }
}