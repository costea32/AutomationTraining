using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class UserShort
    {
        [DataMember]
        public string name
        { get; set; }

        [DataMember]
        public string email
        { get; set; }

        [DataMember]
        public string date
        { get; set; }
    }
}
