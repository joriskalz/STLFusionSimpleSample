using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace STLFusionSimpleSample.Shared.Model
{
    public class DataList
    {
        public List<string> Messages { get; }

        public DataList()
        : this(new List<string>()) { }

        [JsonConstructor]
        public DataList(List<string> messages)
        {
            Messages = messages;
        }
    }
}