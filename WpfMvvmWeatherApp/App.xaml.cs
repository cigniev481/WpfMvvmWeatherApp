using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using SimpleInjector;
using WpfMvvmWeatherApp.Services;
using WpfMvvmWeatherApp.ViewModels;

namespace WpfMvvmWeatherApp
{
    public partial class App : Application
    {
        public static Container Services { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            RegisterServices();
            Start<HomeViewModel>();
        }

        private void RegisterServices()
        {
            Services = new Container();

            Services.RegisterSingleton<IMessenger, Messenger>();
            Services.RegisterSingleton<INavigationService, NavigationService>();
            Services.RegisterSingleton<ILogger, FileLogger>();
            Services.RegisterSingleton<IWeatherApiClient, WeatherApiClient>();
            Services.RegisterSingleton<IForecastStorage, ForecastStorage>();
            Services.RegisterSingleton<HomeViewModel>();
            Services.RegisterSingleton<DetailsViewModel>();
            Services.RegisterSingleton<AddViewModel>();
            Services.RegisterSingleton<MainViewModel>();

            Services.Verify();
        }

        private void Start<T>() where T : ViewModelBase
        {
            var windowViewModel = Services.GetInstance<MainViewModel>();
            windowViewModel.CurrentViewModel = Services.GetInstance<T>();
            var window = new MainWindow {DataContext = windowViewModel};
            window.ShowDialog();
        }
    }
}
