using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public class Folder : Container
    {
        public Folder(string name, string comment, string lastUpdated)
        {
            this.name = name;
            this.comment = comment;
            this.lastUpdated = lastUpdated;
        }

        public string comment { get; set; }
        public string lastUpdated { get; set; }
    }
}
