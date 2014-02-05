using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    public class Branch : Container
    {
        public Branch(string name, string behind, string ahead, string url)
        {
            this.name = name;
            this.behind = behind;
            this.ahead = ahead;
            this.url = url;
        }

        public string behind { get; set; }
        public string ahead { get; set; }
        public string url { get; set; }
    }
}
