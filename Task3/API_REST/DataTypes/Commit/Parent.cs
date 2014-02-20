using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class Parent
    {
        [DataMember]
        public string sha
        { get; set; }

        [DataMember]
        public string url
        { get; set; }

        [DataMember]
        public string html_url
        { get; set; }
    }
}
