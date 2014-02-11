using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Task2
{
    [DataContract(Name = "File")]
    public class File1 : Container
    {
        public File1(string name, string comment, string lastUpdated)
        {
            this.name = name;
            this.comment = comment;
            this.lastUpdated = lastUpdated;
        }

        [DataMember(Order = 2)]
        public string Type { get { return "File"; } set { } }

        [DataMember(Name = "Comment", Order = 3)]
        public string comment { get; set; }

        [DataMember(Name = "LastUpdated", Order = 4)]
        public string lastUpdated { get; set; }
    }
}
