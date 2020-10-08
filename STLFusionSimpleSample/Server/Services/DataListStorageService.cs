using STLFusionSimpleSample.Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace STLFusionSimpleSample.Server.Services
{
    public class DataListStorageService : IDataListStorageService
    {
        private List<string> _messages;

        public DataListStorageService()
        {
            _messages = new List<string>();
        }

        public void AddMessage(string message)
        {
            _messages.Add(message);
        }

        public IEnumerable<string> GetMessages()
        {
            return _messages;
        }
    }
}