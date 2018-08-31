using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinLooker.Services;
using XamarinLooker.ViewModels.Base;
using XamarinLooker.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace XamarinLooker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AuthenticateView();

        }
        private Task InitNavigation()
        {
            var navigationService = ViewModelLocator.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }
        protected override async void OnStart()
        {
            base.OnStart();
            await InitNavigation();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
