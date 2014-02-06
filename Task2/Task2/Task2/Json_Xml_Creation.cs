using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Newtonsoft.Json;
using System.Xml.Linq;

namespace Task2
{
    public class Json_Xml_Creation
    {
        List<Branch> branches;
        string jsonPath = @"c:/Selenium/json.json";
        string xmlPath = @"c:/Selenium/xml.xml";

        public void CreateJson(List<Branch> branches)
        {
            this.branches = branches;

            string json = JsonConvert.SerializeObject(branches, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore
            });

            File.WriteAllText(jsonPath, json);
        }

        public void CreateXml(List<Branch> branches)
        {
            this.branches = branches;
/*
            XElement xml = new XElement("Branches");
            foreach (Branch branch in branches)
            {

                xml.Add(from b in branch
                        select new XElement("Branch",
                            new XElement("Name", b.name),
                            new XElement("Ahead", b.ahead),
                            new XElement("Behind", b.behind),
                            new XElement("Children")));
                XElement children = xml.Element("Children");
            }



            File.WriteAllText(xmlPath, xml.ToString());*/
        }
    }
}
