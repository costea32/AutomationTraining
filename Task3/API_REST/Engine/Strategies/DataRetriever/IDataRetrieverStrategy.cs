using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    interface IDataRetrieverStrategy
    {
        string GetJsonString();
        void WriteToJson(string json);
        void WriteToXml(string json);
    }
}
