﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    interface IDataRetrieverStrategy
    {
        string GetJsonString();
        dynamic GetObject(string js);
    }
}
