using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Task2
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            List<Branch> branches = new MainLogic().getAllStuff();
            Json_Xml_Creation jx = new Json_Xml_Creation();
            jx.CreateJson(branches);
//            jx.CreateXml(branches);
            
        }

    }
}
