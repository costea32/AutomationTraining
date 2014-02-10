using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Xml;

namespace Task2
{
    public class Serializer
    {
        IStrategy strategy;

        List<Container> containers;

        public Serializer(IStrategy strategy, List<Container> containers)
        {
            this.strategy = strategy;
            this.containers = containers;
        }

        public void Execute()
        {
            strategy.Serialize(containers);
        }

        public void setStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }
    }
}
