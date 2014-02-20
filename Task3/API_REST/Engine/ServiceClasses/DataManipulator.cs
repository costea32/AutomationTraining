using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace API_REST
{
    class DataManipulator
    {
        public List<CommitFull> getCommits(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CommitFull>));
            List<CommitFull> cmt = (List<CommitFull>)ser.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(jsonString)));

            return cmt;
        }

        public List<Comment> getComments(string jsonString)
        {
            List<Comment> cmts = new List<Comment>();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CommitFull>));
            List<CommitFull> cmtts = (List<CommitFull>)ser.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(jsonString)));

            foreach (CommitFull cmt in cmtts)
            {
                cmts.Add(new Comment { message = cmt.commit.message.ToString() });
            }

            return cmts;
        }

        public List<Contributor> getContributors(string jsonString)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Contributor>));
            List<Contributor> ctrs = (List<Contributor>)ser.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(jsonString)));
            return ctrs;
        }
    }
    
}
