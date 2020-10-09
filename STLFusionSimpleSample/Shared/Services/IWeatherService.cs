using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Stl.Fusion;
using STLFusionSimpleSample.Shared.Model;

namespace STLFusionSimpleSample.Shared.Services
{
    public interface IWeatherService
    {
        // Readers
        [ComputeMethod(AutoInvalidateTime = 1)]
        Task<IEnumerable<WeatherForecast>> GetAsync(string country, CancellationToken cancellationToken = default);
    }
}