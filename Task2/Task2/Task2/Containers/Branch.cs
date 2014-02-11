using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Task2
{
    [DataContract(Name = "Branch")]
    public class Branch : Container
    {
        public Branch(string name, int behind, int ahead, string url)
        {
            this.name = name;
            this.behind = behind;
            this.ahead = ahead;
            this.url = url;
        }

        [DataMember(Name = "Behind", Order = 3)]
        public int behind { get; set; }

        [DataMember(Name = "Ahead", Order = 2)]
        public int ahead { get; set; }

    }
}
