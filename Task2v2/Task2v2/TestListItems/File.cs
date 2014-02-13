using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    class File : Record
    {
        public File(string name, string comment, string age)
        {
            Name = name;
            Comment = comment;
            Age = age;
        }
    }
}
