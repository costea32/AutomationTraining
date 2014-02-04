using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Record
    {
        public string Name;
        public string Type;
        public string Comment;

        Record(string n, string t, string c)
        {
            Name = n;
            Type = t;
            Comment = c;
        }
    }
}
