using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class DataRetrieverContext
    {
        private IDataRetrieverStrategy strategy;

        public DataRetrieverContext(IDataRetrieverStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IDataRetrieverStrategy strategy)
        {
            this.strategy = strategy;
        }

        public string GetJsonString()
        {
            return this.strategy.GetJsonString();
        }

        public void WriteToJson(string json)
        {
            this.strategy.WriteToJson(json);
        }

        public void WriteToXml(string json)
        {
            this.strategy.WriteToXml(json);
        }
    }
}
