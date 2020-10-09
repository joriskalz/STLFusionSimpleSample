using System.Collections.Generic;

namespace STLFusionSimpleSample.Shared.Services
{
    public interface IDataListStorageService
    {
        public void AddMessage(string message);

        public IEnumerable<string> GetMessages(int lenght);
    }
}
