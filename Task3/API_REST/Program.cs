using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace API_REST
{
    class Program
    {
        static void Main(string[] args)
        {
            AuthDataProvider auth = new AuthDataProvider();

            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("https://api.github.com/users/costea32");
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("Https://api.github.com/repos/costea32/AutomationTraining/commits");
            //HttpWebRequest req = (HttpWebRequest)WebRequest.Create("Https://api.github.com/repos/costea32/AutomationTraining/comments");
            req.Method = "GET";
            req.Headers[HttpRequestHeader.Authorization] = auth.AuthorizationString;
            req.UserAgent= auth.Username;
            req.Accept="application/json";
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            StreamReader sReader = new StreamReader(response.GetResponseStream());
            Console.WriteLine(sReader.ReadToEnd());

            

            Console.ReadLine();
        }
    }
}
