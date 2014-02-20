using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class Worker
    {

        private DataRetrieverContext context;

        public string YieldJsonString()
        {

            return context.GetJsonString();
        }

        public void setDataRetrieverStrategy(int strat)
        {
            switch (strat)
            {
                case 1: { this.context = new DataRetrieverContext(new CommitsStrategy()); } break;
                case 2: { this.context = new DataRetrieverContext(new CommentsStrategy()); } break;
                case 3: { this.context = new DataRetrieverContext(new ContributorsStrategy()); } break;
                default: { Console.WriteLine("Incorrect input."); } break;
            }
        }

        public void WriteToFile(int i, string json)
        {
            switch (i)
            {
                case 1: { context.WriteToJson(json); } break;
                case 2: { context.WriteToXml(json); } break;
                default: { Console.WriteLine("Incorrect input."); } break;
            }
        }

    }
}
