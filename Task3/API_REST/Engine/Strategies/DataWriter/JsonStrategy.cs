using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class JsonStrategy:IDataWriter
    {
        public void WriteData<T>(T obj)
        {
            DataWriter dw = new DataWriter();
            dw.WriteObjectToJsonFile(obj);
        }
    }
}
