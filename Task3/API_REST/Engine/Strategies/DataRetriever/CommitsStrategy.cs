using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class CommitsStrategy:IDataRetrieverStrategy
    {
        public string GetJsonString()
        {
            DataRetriever dr = new DataRetriever();
            dr.setCommand(new Command().GetRepositoryCommits);

            return dr.getDataJsonString();
        }

        public void WriteToJson(string json)
        {
            new DataWriter().WriteCommitsToJsonFile(new DataManipulator().getCommits(json));
        }

        public void WriteToXml(string json)
        {
            new DataWriter().WriteCommitsXmlFile(new DataManipulator().getCommits(json));
        }
    }
}
