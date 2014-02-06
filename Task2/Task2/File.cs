using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class File: Record
    {
        public File(string n, string c, string a)
        {
            Name = n;
            Type = "File";
            Comment = c;
            Age = a;
        }
    }
}
