using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2
{
    class Branch
    {
        public string branchName;
        public int behind;
        public int ahead;
        List<Record> records;

        Branch(string bn, int b, int a)
        {
            branchName = bn;
            behind = b;
            ahead = a;
            records = new List<Record>();
        }
    }
}
