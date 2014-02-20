using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class XmlStrategy:IDataWriter
    {
        public void WriteData<T>(T obj)
        {
            DataWriter dw = new DataWriter();
            dw.WriteObjectToXmlFile(obj);
        }
    }
}
