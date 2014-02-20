using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class Worker
    {

        private DataRetrieverContext context;
        private DataWriterContext writerContext;

        public string YieldJsonString()
        {
            return context.GetJsonString();
        }

        public dynamic GetObject(string js)
        {
            return context.GetObject(js);
        }

        public void WriteObject(dynamic obj)
        {
            this.writerContext.WriteObject(obj);
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

        public void setDataWriterStrategy(int strat)
        {
            switch (strat)
            {
                case 1: { this.writerContext = new DataWriterContext(new JsonStrategy()); } break;
                case 2: { this.writerContext = new DataWriterContext(new XmlStrategy()); } break;
                default: { Console.WriteLine("Incorrect input."); } break;
            }
        }

    }
}
