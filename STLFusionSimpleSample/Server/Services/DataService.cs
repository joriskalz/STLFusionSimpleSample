using Stl.Fusion;
using STLFusionSimpleSample.Shared.Model;
using STLFusionSimpleSample.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace STLFusionSimpleSample.Server.Services
{
    [ComputeService(typeof(IDataService))]
    public class DataService : IDataService
    {
        private readonly IDataListStorageService _dataListStorageService;

        public DataService(IDataListStorageService dataListStorageService)
        {
            _dataListStorageService = dataListStorageService;
        }

        public async Task<string> AddMessageAsync(string text, CancellationToken cancellationToken = default)
        {
            _dataListStorageService.AddMessage(text);

            return text;
        }

        public async Task<DataList> GetDataListAsync(int length, CancellationToken cancellationToken = default)
        {
            return new DataList(_dataListStorageService.GetMessages().ToList());
        }
    }
}