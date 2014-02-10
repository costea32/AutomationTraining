using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Task2
{
    [DataContract(Name = "Folder")]
    public class Folder : Container
    {
        protected internal Folder() { }

        public Folder(string name, string comment, string lastUpdated)
        {
            this.name = name;
            this.comment = comment;
            this.lastUpdated = lastUpdated;
        }

        [DataMember(Order = 2)]
        public string Type { get { return "Folder"; } }

        [DataMember(Name = "Comment", Order = 3)]
        public string comment { get; set; }

        [DataMember(Name = "LastUpdated", Order = 4)]
        public string lastUpdated { get; set; }
    }
}
