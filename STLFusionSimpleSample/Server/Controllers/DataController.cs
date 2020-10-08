using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Stl.Fusion.Bridge;
using Stl.Fusion.Server;
using STLFusionSimpleSample.Shared;
using STLFusionSimpleSample.Shared.Model;
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
    public class DataController : FusionController, IDataService
    {
        private readonly ILogger<DataController> _logger;
        private readonly IDataService _dataService;

        public DataController(IDataService dataService, IPublisher publisher, ILogger<DataController> logger) : base(publisher)
        {
            _logger = logger;
            _dataService = dataService;
        }

        [HttpPost("addMessage")]
        public Task<string> AddMessageAsync(string text, CancellationToken cancellationToken = default)
        {
            text ??= "";
            return _dataService.AddMessageAsync(text, cancellationToken);
        }

        [HttpGet("getData")]
        public Task<DataList> GetDataListAsync(int length, CancellationToken cancellationToken = default)
        {
            return PublishAsync(ct => _dataService.GetDataListAsync(length, ct));
        }
    }
}