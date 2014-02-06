using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Task2
{
    public class Container
    {
//        public IBehavior behavior;

//        public void setBehavior(IBehavior behavior)
//        {
//            this.behavior = behavior;
//        }

//        public void addContainer(Container container1, Container container2)
//        {
//            behavior.addContainer(container1, container2);
//        }

        [JsonProperty("Name", Order = 1)]
        public string name { get; set; }

//        public string type { get; set; }

        [JsonProperty(Order = 5)]
        public List<Container> Children { get; set; }

//        public enum type { file, folder, branch };
//
//        public type getType(Container container)
//        {
//            return type.file;
//        }

    }
}
