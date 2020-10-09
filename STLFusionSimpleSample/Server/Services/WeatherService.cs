using Stl.Fusion;
using STLFusionSimpleSample.Shared;
using STLFusionSimpleSample.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace STLFusionSimpleSample.Server.Services
{
    [ComputeService(typeof(IWeatherService))]
    public class WeatherService : IWeatherService
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public virtual async Task<IEnumerable<WeatherForecast>> GetAsync(string country, CancellationToken cancellationToken = default)
        {
            var rng = new Random();
            var lastValue = 20;
            var list = Enumerable.Range(1, 30).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = ((Func<int>)(() =>
                {
                    var newValue = lastValue + rng.Next(-4, 4);
                    lastValue = newValue;
                    return newValue;
                }))(),
                Summary = $"It is {Summaries[rng.Next(Summaries.Length)]} in {country}"
            })
            .ToArray();

            return list;
        }
    }
}