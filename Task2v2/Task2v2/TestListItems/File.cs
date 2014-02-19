using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Runtime.Serialization;

namespace Task2v2
{
    [DataContract()]
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
