using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace API_REST
{
    class Talker
    {
        public void Main()
        {
            Worker worker = new Worker();
            int i = int.Parse(StartTalk());
            Console.WriteLine("Retrieving data.");
            worker.setDataRetrieverStrategy(i);
            string js = worker.YieldJsonString();
            dynamic obj = worker.GetObject(js);
            i = int.Parse(TalkWrite());
            worker.setDataWriterStrategy(i);
            worker.WriteObject(obj);
        }

        protected string StartTalk()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("Current user: {0}   Current repository:{1} ", "ikulpin", "AutomationTraining");
            Console.WriteLine("====================================================");
            Console.WriteLine("* 1 - Get commites for this repository");
            Console.WriteLine("* 2 - Get comments for this repository");
            Console.WriteLine("* 3 - Get constributors of this repository");
            Console.WriteLine("====================================================");
            Console.Write("Command : ");
            return Console.ReadLine();
        }

        protected string TalkWrite()
        {
            Console.WriteLine("====================================================");
            Console.WriteLine("Current user: {0}   Current repository:{1} ", "ikulpin", "AutomationTraining");
            Console.WriteLine("====================================================");
            Console.WriteLine("* 1 - Write object to json file");
            Console.WriteLine("* 2 - Write object to xml file");
            Console.WriteLine("====================================================");
            Console.Write("Command : ");
            return Console.ReadLine();
        }
    }   
}
