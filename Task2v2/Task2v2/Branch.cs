using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    class Branch
    {
        public string branchName;
        public int behind;
        public int ahead;
        public string link;
        public List<Record> Children;

        public Branch(string bn, int b, int a, string l, List<Record> ch)
        {
            branchName = bn;
            behind = b;
            ahead = a;
            link = l;
            Children = ch;
        }
    }
}
