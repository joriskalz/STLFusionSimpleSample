using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Stl.Fusion;
using STLFusionSimpleSample.Shared.Model;

namespace STLFusionSimpleSample.Shared.Services
{
    public interface IDataService
    {
        // Writers
        Task<string> AddMessageAsync(string text, CancellationToken cancellationToken = default);

        // Readers
        [ComputeMethod(KeepAliveTime = 10)]
        Task<DataList> GetDataListAsync(int length, CancellationToken cancellationToken = default);
    }
}