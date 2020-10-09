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
            var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = $"It is {Summaries[rng.Next(Summaries.Length)]} in {country}"
            })
            .ToArray();

            return list;
        }
    }
}