using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class Week
    {
        [DataMember]
        public int w { get; set; }

        [DataMember]
        public int a { get; set; }

        [DataMember]
        public int d { get; set; }

        [DataMember]
        public int c { get; set; }
    }
}
