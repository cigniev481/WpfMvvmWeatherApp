using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using WpfMvvmWeatherApp.Messages;
using WpfMvvmWeatherApp.Models;
using WpfMvvmWeatherApp.Services;

namespace WpfMvvmWeatherApp.ViewModels
{
    class HomeViewModel : ViewModelBase
    {
        private readonly IForecastStorage _forecastStorage;
        private readonly IMessenger _messenger;
        private readonly INavigationService _navigationService;

        private ObservableCollection<Forecast> forecasts;
        public ObservableCollection<Forecast> Forecasts
        {
            get => forecasts;
            set => Set(ref forecasts, value);
        }

        private Forecast _selectedForecast;
        public Forecast SelectedForecast
        {
            get => _selectedForecast;
            set
            {
                Set(ref _selectedForecast, value);
                RemoveCommand.RaiseCanExecuteChanged();
            }
        }

        //Dependency Injection (DI)
        public HomeViewModel(IForecastStorage forecastStorage, IMessenger messenger, INavigationService navigationService)
        {
            _forecastStorage = forecastStorage;
            _messenger = messenger;
            _navigationService = navigationService;
            if (_forecastStorage != null)
                Forecasts = new ObservableCollection<Forecast>(_forecastStorage.GetAllForecasts());
        }

        private RelayCommand _addCommand;
        public RelayCommand AddCommand => _addCommand ??= new RelayCommand(
            () =>
            {
                _navigationService.NavigateTo<AddViewModel>();
            }
        );

        private RelayCommand<Forecast> _detailsCommand;
        public RelayCommand<Forecast> DetailsCommand => _detailsCommand ??= new RelayCommand<Forecast>(
            param =>
            {
                if (param != null)
                {
                    _navigationService.NavigateTo<DetailsViewModel>();
                    _messenger.Send(new ForecastDetailsMessage { Forecast = param });
                }
                else
                {
                    MessageBox.Show("Please choose the city!");
                }
            }
        );

        private RelayCommand<Forecast> _removeCommand;
        public RelayCommand<Forecast> RemoveCommand => _removeCommand ??= new RelayCommand<Forecast>(
            param =>
            {
                _forecastStorage.RemoveForecast(param);
                Forecasts.Remove(param);
            },
            param => SelectedForecast != null
        );
    }

    class FakeHomeViewModel : HomeViewModel
    {
        public FakeHomeViewModel() : base(null, null, null)
        {
            Forecasts = new ObservableCollection<Forecast>
            {
                new Forecast { Name = "Baku", Main = new Main { Temperature = 24 } },
                new Forecast { Name = "Kiev", Main = new Main { Temperature = 32 } },
                new Forecast { Name = "Moscow", Main = new Main { Temperature = 12 } }
            };
        }
    }
}
