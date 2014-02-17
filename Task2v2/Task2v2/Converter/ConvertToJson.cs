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
            string filePath = @"C:\Users\goncharenkoa\Documents\Task2_output\JSON_output.json";

            var serializer = new DataContractJsonSerializer(typeof(List<Branch>));
            //using (var stream = File.Open(filePath, FileMode.Create, FileAccess.Write))
            //{
            //    serializer.WriteObject(stream, branchList);
            //}
        }
    }
}
