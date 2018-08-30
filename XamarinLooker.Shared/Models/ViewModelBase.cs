using System.Threading.Tasks;

namespace XamarinLooker.Shared
{
    public abstract class ViewModelBase : ExtendedBindableObject
    {

        private bool _isBusy;

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

        public virtual Task InitializeAsync(object navigationData)
        {
            return Task.FromResult(false);
        }
    }
}

