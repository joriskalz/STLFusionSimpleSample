using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stl.Fusion.Bridge;
using Stl.Fusion.Server;
using STLFusionSimpleSample.Shared;
using STLFusionSimpleSample.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace STLFusionSimpleSample.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : FusionController, IWeatherService
    {
        private readonly ILogger<WeatherForecastController> logger;
        private readonly IWeatherService _weatherService;

        public WeatherForecastController(IWeatherService weatherService, IPublisher publisher, ILogger<WeatherForecastController> logger) : base(publisher)
        {
            this.logger = logger;
            _weatherService = weatherService;
        }

        [HttpGet("getAsync")]
        public Task<IEnumerable<WeatherForecast>> GetAsync(string country, CancellationToken cancellationToken = default)
        {
            return PublishAsync(ct => _weatherService.GetAsync(country ?? string.Empty, ct));
        }
    }
}