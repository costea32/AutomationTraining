using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Xml;
using System.Runtime.Serialization;

namespace Task2v2
{
    [DataContract(Name = "Branch")]
    [KnownType(typeof(Record))]
    public class Branch
    {
        [DataMember(Name = "BranchName")]
        public string branchName;

        [DataMember(Name = "Behind")]
        public int behind;

        [DataMember(Name = "Ahead")]
        public int ahead;

        [DataMember(Name = "Children")]
        public List<Record> Children;

        public Branch(string bn, int b, int a, List<Record> ch)
        {
            branchName = bn;
            behind = b;
            ahead = a;
            Children = ch;
        }

        public Branch() { }
    }
}
