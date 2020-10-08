using RestEase;
using Stl.Fusion.Client;
using Stl.Fusion.Client.RestEase;
using STLFusionSimpleSample.Shared.Model;
using STLFusionSimpleSample.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace STLFusionSimpleSample.Client.Services
{
    [RestEaseReplicaService(typeof(IDataService), Scope = Program.ClientSideScope)]
    [BasePath("data")]
    public interface IDataClient : IRestEaseReplicaClient
    {
        // Writers
        [Post("addMessage")]
        Task<string> AddMessageAsync(string text, CancellationToken cancellationToken = default);

        // Readers
        [Get("getData")]
        Task<DataList> GetDataListAsync(int length, CancellationToken cancellationToken = default);
    }
}