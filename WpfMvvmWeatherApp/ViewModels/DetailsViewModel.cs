using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Maps.MapControl.WPF;
using WpfMvvmWeatherApp.Messages;
using WpfMvvmWeatherApp.Services;

namespace WpfMvvmWeatherApp.ViewModels
{
    class DetailsViewModel : ViewModelBase
    {
        private readonly IMessenger _messenger;

        public DetailsViewModel(IMessenger messenger)
        {
            _messenger = messenger;

            _messenger?.Register<ForecastDetailsMessage>(this, message =>
            {
                CityName = message.Forecast.Name;
                Temperature = message.Forecast.Main.Temperature.ToString();
                var icon = message.Forecast.Weather[0].Icon;
                Image = $"http://openweathermap.org/img/wn/{icon}@2x.png";
                Location = new Location(message.Forecast.Coord.Latitude, message.Forecast.Coord.Longitude);
            });
        }

        private string _cityName;
        public string CityName
        {
            get => _cityName;
            set => Set(ref _cityName, value);
        }

        private string _image;
        public string Image
        {
            get => _image;
            set => Set(ref _image, value);
        }

        private string _temperature;
        public string Temperature
        {
            get => _temperature;
            set => Set(ref _temperature, value);
        }

        private Location _location;
        public Location Location
        {
            get => _location;
            set => Set(ref _location, value);
        }

        private RelayCommand backCommand;
        public RelayCommand BackCommand => backCommand ??= new RelayCommand(
            () =>
            {
                _messenger.Send(new NavigationMessage { ViewModelType = typeof(HomeViewModel) });
            }
        );
    }

    class FakeDetailsViewModel : DetailsViewModel
    {
        public FakeDetailsViewModel() : base(null)
        {
            CityName = "Baku";
            Temperature = "22";
            Location = new Location(20, -40);
        }
    }
}
