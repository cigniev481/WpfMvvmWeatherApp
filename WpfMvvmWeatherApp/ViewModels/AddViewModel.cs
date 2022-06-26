using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfMvvmWeatherApp.Attribuites;
using WpfMvvmWeatherApp.Messages;
using WpfMvvmWeatherApp.Services;

namespace WpfMvvmWeatherApp.ViewModels
{
    class AddViewModel : ViewModelBase, IDataErrorInfo
    {
        private readonly IMessenger _messenger;
        private readonly IWeatherApiClient _weatherApiClient;
        private readonly IForecastStorage _forecastStorage;

        public AddViewModel(IMessenger messenger, IWeatherApiClient weatherApiClient, IForecastStorage forecastStorage)
        {
            _messenger = messenger;
            _weatherApiClient = weatherApiClient;
            _forecastStorage = forecastStorage;

            //_messenger.Register<LocationMessage>(this, message =>
            //{
            //    Longitude = message.Longitude.ToString();
            //    Latitude = message.Latitude.ToString();
            //});
        }

        private string _cityName;
        [Required(ErrorMessage = "Please fill city name")]
        public string CityName
        {
            get => _cityName;
            set
            {
                Set(ref _cityName, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private string _latitude;
        [GeoCoordinate]
        public string Latitude
        {
            get => _latitude;
            set
            {
                Set(ref _latitude, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private string _longitude;
        [GeoCoordinate]
        public string Longitude
        {
            get => _longitude;
            set
            {
                Set(ref _longitude, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _findByName = true;
        public bool FindByName
        {
            get => _findByName;
            set
            {
                Set(ref _findByName, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _findByGeolocation;
        public bool FindByGeolocation
        {
            get => _findByGeolocation;
            set
            {
                Set(ref _findByGeolocation, value);
                OkCommand.RaiseCanExecuteChanged();
            }
        }

        private RelayCommand _okCommand;
        public RelayCommand OkCommand => _okCommand ??= new RelayCommand(
            () =>
            {
                if (FindByName)
                {
                    var forecast = _weatherApiClient.GetForecastByCityName(CityName);
                    _forecastStorage.AddForecast(forecast);
                }
                else
                {
                    var latitude = double.Parse(Latitude);
                    var longitude = double.Parse(Longitude);
                    var forecast = _weatherApiClient.GetForecastByGeolocation(latitude, longitude);
                    _forecastStorage.AddForecast(forecast);
                }
                _messenger.Send(new NavigationMessage { ViewModelType = typeof(HomeViewModel) });
            },
            () => (FindByName && !string.IsNullOrWhiteSpace(CityName)) || 
                          (FindByGeolocation && !string.IsNullOrWhiteSpace(Latitude) && !string.IsNullOrWhiteSpace(Longitude))
        );

        private RelayCommand _cancelCommand;
        public RelayCommand CancelCommand => _cancelCommand ??= new RelayCommand(
            () =>
            {
                _messenger.Send(new NavigationMessage { ViewModelType = typeof(HomeViewModel)});
            }
        );

        public string Error { get; }

        public string this[string columnName]
        {
            get
            {
                var validationContext = new ValidationContext(this);
                List<ValidationResult> results = new List<ValidationResult>();
                var isValid = Validator.TryValidateObject(this, validationContext, results, true);

                if (isValid)
                    return string.Empty;

                var result = results.FirstOrDefault(x => x.MemberNames.Contains(columnName));

                if (result is null)
                    return string.Empty;

                return result.ErrorMessage;
            }
        }
    }
}
