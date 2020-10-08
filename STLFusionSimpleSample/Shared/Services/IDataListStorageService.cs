using System;
using System.Collections.Generic;
using System.Text;

namespace STLFusionSimpleSample.Shared.Services
{
    public interface IDataListStorageService
    {
        public void AddMessage(string message);

        public IEnumerable<string> GetMessages(int lenght);
    }
}