using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Windows;
using WpfMvvmWeatherApp.Models;

namespace WpfMvvmWeatherApp.Services
{
    class WeatherApiClient : IWeatherApiClient
    {
        private readonly ILogger _logger;
        private readonly WebClient _webClient;

        private readonly string _appId = "835492c0eab300994ec658dfb16ad305";
        private readonly string _units = "metric";
        private readonly string _apiUrl = "http://api.openweathermap.org/data/2.5";

        public WeatherApiClient(ILogger logger)
        {
            _logger = logger;
            _webClient = new WebClient();
        }

        public Forecast GetForecastByCityName(string cityName)
        {
            try
            {
                var json = _webClient.DownloadString($"{_apiUrl}/weather?q={cityName}&appid={_appId}&units={_units}");
                var forecast = JsonSerializer.Deserialize<Forecast>(json,
                    new JsonSerializerOptions {PropertyNameCaseInsensitive = true});
                return forecast;
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR!!!", ex);
                throw;
            }
        }

        public Forecast GetForecastByGeolocation(double latitude, double longitude)
        {
            try
            {
                var json = _webClient.DownloadString($"{_apiUrl}/weather?lat={latitude}&lon={longitude}&appid={_appId}&units={_units}");
                var forecast = JsonSerializer.Deserialize<Forecast>(json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return forecast;
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR!!!", ex);
                throw;
            }
        }
    }
}
