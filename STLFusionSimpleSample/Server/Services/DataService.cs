using Stl.Async;
using Stl.Fusion;
using STLFusionSimpleSample.Shared.Model;
using STLFusionSimpleSample.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
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

        public virtual async Task<string> AddMessageAsync(string text, CancellationToken cancellationToken = default)
        {
            _dataListStorageService.AddMessage(text);

            // Invalidation
            Computed.Invalidate(EveryDataList);

            return text;
        }

        public virtual async Task<DataList> GetDataListAsync(int length, CancellationToken cancellationToken = default)
        {
            await EveryDataList().ConfigureAwait(false);

            return new DataList(_dataListStorageService.GetMessages(length).ToList());
        }

        [ComputeMethod]
        protected virtual Task<Unit> EveryDataList() => TaskEx.UnitTask;

    }
}