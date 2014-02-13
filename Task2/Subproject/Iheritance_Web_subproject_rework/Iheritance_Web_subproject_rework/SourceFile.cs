using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Iheritance_Web_subproject_rework
{
    [DataContract]
    class SourceFile
    {

        [DataMember]
        public string Name
        { get; set; }

        [DataMember]
        public string Type
        { get; set; }

        [DataMember]
        public string Comment
        {
            get;
            set;
        }


        [DataMember]
        public string Last_updated
        {
            get;
            set;
        }

        public bool IsAFolder { get; set; }
    }
}
