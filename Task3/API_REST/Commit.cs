using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class Commit
    {
        [DataMember]
        public UserShort author
        { get; set; }

        [DataMember]
        public UserShort committer
        { get; set; }

        [DataMember]
        public string message
        { get; set; }

        [DataMember]
        public Tree tree
        { get; set; }

        [DataMember]
        public string url
        { get; set; }

        [DataMember]
        public int commit_count
        { get; set; }
    }
}
