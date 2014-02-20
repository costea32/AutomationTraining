using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class ContributorsStrategy:IDataRetrieverStrategy
    {
        public string GetJsonString()
        {
            DataRetriever dr = new DataRetriever();
            dr.setCommand(new Command().GetContributorsList);

            return dr.getDataJsonString();
        }

        public void WriteToJson(string json)
        {
            new DataWriter().WriteContributorsToJsonFile(new DataManipulator().getContributors(json));
        }

        public void WriteToXml(string json)
        {
            new DataWriter().WriteContributorsToXmlFile(new DataManipulator().getContributors(json));
        }
    }
}
