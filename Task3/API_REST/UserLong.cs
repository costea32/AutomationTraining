using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace API_REST
{
    [DataContract]
    class UserLong
    {
        [DataMember]
        public string login
        { get; set; }

        [DataMember]
        public int id
        { get; set; }

        [DataMember]
        public string avatar_url
        { get; set; }

        [DataMember]
        public string gravatar_id
        { get; set; }

        [DataMember]
        public string url
        { get; set; }

        [DataMember]
        public string html_url
        { get; set; }

        [DataMember]
        public string followers_url
        { get; set; }

        [DataMember]
        public string following_url
        { get; set; }

        [DataMember]
        public string gists_url
        { get; set; }

        [DataMember]
        public string starred_url
        { get; set; }

        [DataMember]
        public string subscriptions_url
        { get; set; }

        [DataMember]
        public string organizations_url
        { get; set; }

        [DataMember]
        public string repos_url
        { get; set; }

        [DataMember]
        public string events_url
        { get; set; }

        [DataMember]
        public string received_events_url
        { get; set; }

        [DataMember]
        public string type
        { get; set; }

        [DataMember]
        public bool site_admin
        { get; set; }

    }
}
