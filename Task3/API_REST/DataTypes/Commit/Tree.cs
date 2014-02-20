using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class Tree
    {
        [DataMember]
        public string sha
        { get; set; }

        [DataMember]
        public string url
        { get; set; }
    }
}
