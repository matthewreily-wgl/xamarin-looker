using System.Threading.Tasks;
using XamarinLooker.Model;
using XamarinLooker.ViewModels.Base;

namespace XamarinLooker.ViewModels
{
    public class LookDetailsViewModel : ViewModelBase
    {
        private Look _look;

        public override async Task InitializeAsync(object navigationData)
        {
            if (navigationData is Look)
            {
                IsBusy = true;
                LookDetails = (Look) navigationData;
            }
        }

        public Look LookDetails
        {
            get => _look;
            set
            {
                RaisePropertyChanged(()=>LookDetails);
                _look = value;
            }
        }
    }
}