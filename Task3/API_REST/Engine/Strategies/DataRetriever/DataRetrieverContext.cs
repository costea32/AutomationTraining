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

        public dynamic GetObject(string js)
        {
            return this.strategy.GetObject(js);
        }
    }
}
