using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class Contributor
    {
        [DataMember]
        public int total { get; set; }

        [DataMember]
        public List<Week> weeks { get; set; }

        [DataMember]
        public UserLong author { get; set; }
    }
}
