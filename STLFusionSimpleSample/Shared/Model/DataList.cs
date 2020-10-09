using Newtonsoft.Json;
using System.Collections.Generic;

namespace STLFusionSimpleSample.Shared.Model
{
    public class DataList
    {
        public List<string> Messages { get; }

        public DataList() : this(new List<string>()) { }

        [JsonConstructor]
        public DataList(List<string> messages)
        {
            Messages = messages;
        }
    }
}
