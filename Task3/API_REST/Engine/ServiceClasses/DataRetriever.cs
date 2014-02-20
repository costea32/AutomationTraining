using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace API_REST
{
    class DataRetriever
    {
        private string command_href = "Https://api.github.com";



        public void setCommand(string href)
        {
            flushCommand();
            command_href += href;
        }

        public string getDataJsonString()
        {
            AuthDataProvider auth = new AuthDataProvider();

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(command_href);
            req.Method = "GET";
            req.Headers[HttpRequestHeader.Authorization] = auth.AuthorizationString;
            req.UserAgent = auth.Username;
            req.Accept = "application/json";

            HttpWebResponse response = (HttpWebResponse)req.GetResponse();

            var responseStream = new StreamReader(response.GetResponseStream());
            string jsonString = responseStream.ReadToEnd();
            return jsonString;
        }

        protected void flushCommand()
        {
            command_href = "Https://api.github.com";
        }
    }
}
