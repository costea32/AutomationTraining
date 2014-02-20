using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Json;

namespace API_REST
{
    class DataWriter
    {

        public void WriteCommentsToXml(List<CommitFull> coll)
        {
            string xml_path = @"C:\temp\API_REST\COMMENTS_XML_OUTPUT.xml";
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

        public void WriteCommentsToJson(List<CommitFull> coll)
        {
            string json_path = @"C:\temp\API_REST\COMMENTS_JSON_OUTPUT.txt";
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Comment>));
            MemoryStream mStream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(json_path, true);

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

        public void WriteCommitsToJsonFile(List<CommitFull> coll)
        {
            string json_path = @"C:\temp\API_REST\COMMITS_JSON_OUTPUT.txt";
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CommitFull>));
            MemoryStream mStream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(json_path, true);

            ser.WriteObject(mStream, coll);
            string jsonString = Encoding.Default.GetString(mStream.ToArray());
            sWriter.Write(jsonString);
            sWriter.Close();
        }

        public void WriteCommitsXmlFile(List<CommitFull> coll)
        {
            string xml_path = @"C:\temp\API_REST\COMMITS_XML_OUTPUT.xml";
            DataContractSerializer ser = new DataContractSerializer(typeof(List<CommitFull>));
            StreamWriter sWriter = new StreamWriter(xml_path, true);
            MemoryStream mStream = new MemoryStream();

            ser.WriteObject(mStream, coll);
            string xmlString = Encoding.Default.GetString(mStream.ToArray());
            sWriter.Write(xmlString);
            sWriter.Close();
        }

        public void WriteContributorsToJsonFile(List<Contributor> ctrs)
        {
            string path = @"C:\temp\API_REST\CONTRIBUTORS_JSON_OUTPUT.txt";
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Contributor>));
            MemoryStream mStream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(path, true);
            
            ser.WriteObject(mStream,ctrs);
            string jsonString = Encoding.Default.GetString(mStream.ToArray());
            sWriter.Write(jsonString);
            sWriter.Close();
        }

        public void WriteContributorsToXmlFile(List<Contributor> ctrs)
        {
            string path = @"C:\temp\API_REST\CONTRIBUTORS_XML_OUTPUT.xml";
            DataContractSerializer ser = new DataContractSerializer(typeof(List<Contributor>));
            MemoryStream mStream = new MemoryStream();
            StreamWriter sWriter = new StreamWriter(path, true);

            ser.WriteObject(mStream, ctrs);
            string xmlString = Encoding.Default.GetString(mStream.ToArray());
            sWriter.Write(xmlString);
            sWriter.Close();
        }
    }
}
