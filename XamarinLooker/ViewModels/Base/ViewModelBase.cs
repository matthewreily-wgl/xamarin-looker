using System.Threading.Tasks;
using XamarinLooker.Services;

namespace XamarinLooker.ViewModels.Base
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {

        private bool _isBusy;

        public ViewModelBase()
        {
            NavigationService = ViewModelLocator.Resolve<INavigationService>();
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }

            set
            {
                _isBusy = value;
                RaisePropertyChanged(() => IsBusy);
            }
        }

        public INavigationService NavigationService { get; }

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}

