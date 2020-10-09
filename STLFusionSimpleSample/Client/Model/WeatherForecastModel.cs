using STLFusionSimpleSample.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFusionSimpleSample.Client.Model
{
    public class WeatherForecastModel
    {
        public IEnumerable<WeatherForecast> Forecast { get; set; } = new WeatherForecast[] { };
    }
}