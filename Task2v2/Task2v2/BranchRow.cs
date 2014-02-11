using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task2v2
{
    class BranchRow
    {
        public string BranchName;
        public int Behind;
        public int Ahead;

        public BranchRow(string name, int behind, int ahead)
        {
            BranchName = name;
            Behind = behind;
            Ahead = ahead;
        }

        public BranchRow(BranchRow r)
        {
            BranchName = r.BranchName;
            Behind = r.Behind;
            Ahead = r.Ahead;
        }
    }
}
