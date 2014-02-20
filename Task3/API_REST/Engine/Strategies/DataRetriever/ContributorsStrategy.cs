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


        public dynamic GetObject(string js)
        {
            return new DataManipulator().getContributors(js);
        }
    }
}
