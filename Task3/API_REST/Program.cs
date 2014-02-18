using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace API_REST
{
    class Program
    {
        const string json_path = @"C:\temp\API_REST\json_output.txt";
        static void Main(string[] args)
        {
            AuthDataProvider auth = new AuthDataProvider();
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create("Https://api.github.com/repos/costea32/AutomationTraining/commits");
            req.Method = "GET";
            req.Headers[HttpRequestHeader.Authorization] = auth.AuthorizationString;
            req.UserAgent= auth.Username;
            req.Accept="application/json";
            HttpWebResponse response = (HttpWebResponse)req.GetResponse();
            var responseStream = new StreamReader(response.GetResponseStream());
            string jsonString = responseStream.ReadToEnd();

            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CommitFull>));
            var mStream = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));

            List<CommitFull> cmt = (List<CommitFull>)ser.ReadObject(new MemoryStream(Encoding.UTF8.GetBytes(jsonString)));

            WriteToJsonFile(cmt);
            WriteToXmlFile(cmt);

            WriteCommentsToJson(cmt);
            WriteCommentsToXml(cmt);




            Console.WriteLine("Push ze button");
            Console.ReadLine();
        }

        private static void WriteCommentsToXml(List<CommitFull> coll)
        {
            string xml_path = @"C:\temp\API_REST\COMMENTS_XML_OUTPUT.txt";
            DataContractSerializer ser = new DataContractSerializer(typeof(List<Comment>));
            MemoryStream mStream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(xml_path, true);

            List<Comment> cmts = new List<Comment>();

            foreach (CommitFull cmt in coll)
            {
                cmts.Add(new Comment { message = cmt.commit.message.ToString() });
            }

            ser.WriteObject(mStream, cmts);
            string jsonString = Encoding.Default.GetString(mStream.ToArray());
            sWriter.Write(jsonString);
            sWriter.Close();
            
        }

        private static void WriteCommentsToJson(List<CommitFull> coll)
        {
            string json_path = @"C:\temp\API_REST\COMMENTS_JSON_OUTPUT.txt";
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Comment>));
            MemoryStream mStream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(json_path,true);

            List<Comment> cmts = new List<Comment>();

            foreach (CommitFull cmt in coll)
            {
                cmts.Add(new Comment { message = cmt.commit.message.ToString() });
            }

            ser.WriteObject(mStream,cmts);
            string jsonString = Encoding.Default.GetString(mStream.ToArray());
            sWriter.Write(jsonString);
            sWriter.Close();
        }

        public static void WriteToJsonFile(List<CommitFull> coll)
        {
            string json_path = @"C:\temp\API_REST\JSON_OUTPUT.txt";
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CommitFull>));
            MemoryStream mStream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(json_path,true);

            ser.WriteObject(mStream,coll);
            string jsonString = Encoding.Default.GetString(mStream.ToArray());
            sWriter.Write(jsonString);
            sWriter.Close();
        }

        public static void WriteToXmlFile(List<CommitFull> coll)
        {
            string xml_path = @"C:\temp\API_REST\XML_OUTPUT.txt";
            DataContractSerializer ser = new DataContractSerializer(typeof(List<CommitFull>));
            StreamWriter sWriter = new StreamWriter(xml_path, true);
            MemoryStream mStream = new MemoryStream();

            ser.WriteObject(mStream, coll);
            string xmlString = Encoding.Default.GetString(mStream.ToArray());
            sWriter.Write(xmlString);
            sWriter.Close();
        }
    }
}
