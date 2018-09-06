
using System;
using System.Globalization;
using System.Reflection;
using Unity;
using Unity.Lifetime;
using Xamarin.Forms;
using XamarinLooker.Repositories;
using XamarinLooker.Services;

namespace XamarinLooker.ViewModels.Base
{
    public static class ViewModelLocator
    {
        private static readonly UnityContainer _container;

        public static readonly BindableProperty AutoWireViewModelProperty =
            BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

        public static bool GetAutoWireViewModel(BindableObject bindable)
        {
            return (bool)bindable.GetValue(ViewModelLocator.AutoWireViewModelProperty);
        }

        public static void SetAutoWireViewModel(BindableObject bindable, bool value)
        {
            bindable.SetValue(ViewModelLocator.AutoWireViewModelProperty, value);
        }

        static ViewModelLocator()
        {
            _container = new UnityContainer();

            _container.RegisterSingleton<AuthenticateViewModel>();
            _container.RegisterSingleton<LooksViewModel>();
            _container.RegisterSingleton<LookDetailsViewModel>();
            _container.RegisterSingleton<PerformLookViewModel>();
            _container.RegisterType<ICameraService, CameraService>();
            ISettingsService settingService = new SettingsService(new InMemorySettingsRepository());

            

            _container.RegisterInstance(settingService);
            _container.RegisterInstance<INetworkService>(new NetworkService(settingService));
            _container.RegisterInstance<INavigationService>(new NavigationService(settingService));


        }

        public static T Resolve<T>() where T : class
        {
            return _container.Resolve<T>();
        }

        private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var view = bindable as Element;
            if (view == null)
            {
                return;
            }

            var viewType = view.GetType();
            var viewName = viewType.Name.Replace(".Views.", ".ViewModels.");
            var viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}.{1}Model, {2}", "XamarinLooker.ViewModels", viewName, "XamarinLooker");

            var viewModelType = Type.GetType(viewModelName);
            if (viewModelType == null)
            {
                return;
            }
            var viewModel = _container.Resolve(viewModelType);
            view.BindingContext = viewModel;
        }
    }

    public class SettingsRepository : ISettingsRepository
    {
    }

    public interface ISettingsRepository
    {
        
    }
}

