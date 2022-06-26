using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using WpfMvvmWeatherApp.Models;

namespace WpfMvvmWeatherApp.Services
{
    class ForecastStorage : IForecastStorage
    {
        private readonly ILogger _logger;
        private List<Forecast> _forecasts = new List<Forecast>();
        private const string FileName = "forecasts.json";

        public ForecastStorage(ILogger logger)
        {
            _logger = logger;
            Load();
        }

        public void AddForecast(Forecast forecast)
        {
            _forecasts.Add(forecast);
            Save();
        }

        public void RemoveForecast(Forecast forecast)
        {
            _forecasts.Remove(forecast);
            Save();
        }

        public IEnumerable<Forecast> GetAllForecasts()
        {
            return _forecasts;
        }

        private void Save()
        {
            var json = JsonSerializer.Serialize(_forecasts);
            File.WriteAllText(FileName, json);
        }

        private void Load()
        {
            if (File.Exists(FileName))
            {
                var json = File.ReadAllText(FileName);
                _forecasts = JsonSerializer.Deserialize<List<Forecast>>(json);
            }
        }
    }
}
