using System;
using System.Collections.Generic;
using System.Text;
using WpfMvvmWeatherApp.Models;

namespace WpfMvvmWeatherApp.Services
{
    interface IWeatherApiClient
    {
        Forecast GetForecastByCityName(string cityName);
        Forecast GetForecastByGeolocation(double latitude, double longitude);
    }
}
