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
            List<Container> containers = new MainLogic().GetAllStuff();
            Serializer serializer = new Serializer(new JsonStrategy(),containers);
            serializer.Execute();
            serializer.setStrategy(new XmlStrategy());
            serializer.Execute();
        }

    }
}
