using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    interface IDataWriter
    {
        void WriteData<T>(T obj);
    }
}
