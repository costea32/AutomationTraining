using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class File: Record
    {
        File(string n, string t, string c)
        {
            Name = n;
            Type = t;
            Comment = c;
        }
    }
}
