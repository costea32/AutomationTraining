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
        public List<Record> Children;

        public Branch(string bn, int b, int a, List<Record> ch)
        {
            branchName = bn;
            behind = b;
            ahead = a;
            Children = ch;
        }
    }
}
