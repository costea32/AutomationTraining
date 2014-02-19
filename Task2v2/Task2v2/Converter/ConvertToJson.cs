using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Task2v2
{
    class ConvertToJson : Converter
    {
        public void ConvertToFile(List<Branch> branchList)
        {
            string timeStamp = DateTime.Now.ToString().Replace("/", "_").Replace(":", "-");
            string output = @"C:\Users\goncharenkoa\Documents\Task2_output\JSON_output_" + timeStamp + ".json";

            FileStream writer = new FileStream(output, FileMode.Create);
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Branch>));

            foreach (Branch b in branchList)
            {
                serializer.WriteObject(writer, b);
            }

            writer.Close();
            Console.WriteLine("\nXML file created.\n");

            //var serializer = new DataContractJsonSerializer(typeof(List<Branch>));
            //using (var stream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            //{
            //    serializer.WriteObject(stream, branchList);
            //}
        }
    }
}
