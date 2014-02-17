using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class CommitFull
    {
        [DataMember]
        public string sha
        { get; set; }

        [DataMember]
        public Commit commit
        { get; set; }

        [DataMember]
        public string url
        { get; set; }

        [DataMember]
        public string html_url
        { get; set; }

        [DataMember]
        public string comments_url
        { get; set; }

        [DataMember]
        public UserLong author
        { get; set; }

        [DataMember]
        public UserLong committer
        { get; set; }

        [DataMember]
        public Parent[] parents
        { get; set; }
    }
}
