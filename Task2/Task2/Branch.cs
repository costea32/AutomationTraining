using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Branch: Actions
    {
        public string branchName;
        public int behind;
        public int ahead;
        public List<Record> records;
        public string link;

        public Branch(string bn, int b, int a, string l)
        {
            branchName = bn;
            behind = b;
            ahead = a;
            records = new List<Record>();
            link = l;
        }
    }
}
