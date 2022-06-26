using System;
using System.Collections.Generic;
using System.Text;
using WpfMvvmWeatherApp.Models;

namespace WpfMvvmWeatherApp.Services
{
    interface IForecastStorage
    {
        void AddForecast(Forecast forecast);
        void RemoveForecast(Forecast forecast);
        IEnumerable<Forecast> GetAllForecasts();
    }
}
