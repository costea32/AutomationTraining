using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class CommentsStrategy:IDataRetrieverStrategy
    {
        public string GetJsonString()
        {
            DataRetriever dr = new DataRetriever();
            dr.setCommand(new Command().GetRepositoryCommits);

            return dr.getDataJsonString();
        }

        public void WriteToJson(string json)
        {
            new DataWriter().WriteCommentsToJson(new DataManipulator().getCommits(json));
        }

        public void WriteToXml(string json)
        {
            new DataWriter().WriteCommentsToXml(new DataManipulator().getCommits(json));
        }
    }
}
