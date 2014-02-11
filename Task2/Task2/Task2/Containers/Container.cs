using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Task2
{
    [DataContract]
    [KnownType(typeof(Branch))]
    [KnownType(typeof(Folder))]
    [KnownType(typeof(File1))]
    public class Container
    {
        [DataMember(Name="Name", Order = 1)]
        public string name { get; set; }

        [DataMember(Name="Children", Order=5, EmitDefaultValue = false)]
        public List<Container> children { get; set; }

        [IgnoreDataMember]
        public string url { get; set; }

    }
}
