using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class CommitsCollection
    {
        [DataMember]
        public CommitFull[] collection
        { get; set; }
    }
}
