using System.Collections.ObjectModel;
using XamarinLooker.Model;
using XamarinLooker.Services;
using XamarinLooker.ViewModels.Base;

namespace XamarinLooker.ViewModels
{
    public class LooksViewModel : ViewModelBase
    {
        private Look _selectedLook;
        public ObservableCollection<Look> Looks { get; set; }

        public Look SelectedLook
        {
            get => _selectedLook;

            set
            {
                RaisePropertyChanged(()=>SelectedLook);
                _selectedLook = value;
                NavigationService.NavigateToAsync<LookDetailsViewModel>(SelectedLook);
            } 
        }

        public LooksViewModel(ISettingsService settingsService)
        {
            if (settingsService.UseMockData)
            {
                Looks = new ObservableCollection<Look>()
                {
                    new Look()
                    {
                        JobNumber = "123456789",
                        Distance = "12 miles",
                        LookType = "Auto Inspection"
                    },
                    new Look()
                    {
                        JobNumber = "987654321",
                        Distance = "2 miles",
                        LookType = "Door Hanger"
                    }
                };
            }
        }
    }
}