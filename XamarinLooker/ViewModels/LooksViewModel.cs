using System.Collections.ObjectModel;
using System.Threading.Tasks;
using XamarinLooker.Model;
using XamarinLooker.Services;
using XamarinLooker.ViewModels.Base;

namespace XamarinLooker.ViewModels
{
    public class LooksViewModel : ViewModelBase
    {
        private readonly ISettingsService _settingsService;
        private readonly INetworkService _networkService;
        private Look _selectedLook;
        private ObservableCollection<Look> _looks;

        public ObservableCollection<Look> Looks 
        { 
            get => _looks; 
            set 
            {
                RaisePropertyChanged(() => Looks);
                _looks = value; 
            } 
        }

        public Look SelectedLook
        {
            get => _selectedLook;

            set
            {
                RaisePropertyChanged(() => SelectedLook);
                _selectedLook = value;
                NavigationService.NavigateToAsync<LookDetailsViewModel>(SelectedLook);
            }
        }

        public LooksViewModel(ISettingsService settingsService, INetworkService networkService)
        {
            _settingsService = settingsService;
            _networkService = networkService;
            Looks = new ObservableCollection<Look>();
        }
        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;
            Looks = await GetLooks();
            IsBusy = false;
        }

        private async Task<ObservableCollection<Look>> GetLooks()
        {
            if (_settingsService.UseMockData)
            {
                return new ObservableCollection<Look>()
                {
                    new Look
                    {
                        JobNumber = "123456789",
                        Distance = "12 miles",
                        Schema = new Schema{Name = "Vehicle Verification", LookerFee = "2000"},
                        DueDates = new DueDates{
                            Looker = new DateFragments
                            {
                                Date="25",
                                Month="12",
                                Year="2018"
                            }
                        }
                    },
                    new Look
                    {
                        JobNumber = "987654321",
                        Distance = "2 miles",
                        Schema = new Schema{Name = "Door Hanger", LookerFee = "200"},
                         DueDates = new DueDates{
                            Looker = new DateFragments
                            {
                                Date="25",
                                Month="12",
                                Year="2018"
                            }
                        }
                    }
                };
            }
            else
            {
                return new ObservableCollection<Look>(await _networkService.GetLooks());
            }
        }
    }
}