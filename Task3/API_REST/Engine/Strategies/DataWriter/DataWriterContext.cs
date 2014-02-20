using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class DataWriterContext
    {
        IDataWriter strategy;

        public DataWriterContext(IDataWriter strategy)
        {
            this.strategy = strategy;
        }

        public void setStrategy(IDataWriter strategy)
        {
            this.strategy = strategy;
        }

        public void WriteObject<T>(T obj)
        {
            this.strategy.WriteData(obj);
        }
    }
}
