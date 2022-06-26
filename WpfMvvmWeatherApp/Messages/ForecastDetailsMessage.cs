using System;
using System.Collections.Generic;
using System.Text;
using WpfMvvmWeatherApp.Models;

namespace WpfMvvmWeatherApp.Messages
{
    class ForecastDetailsMessage
    {
        public Forecast Forecast { get; set; }
    }
}
