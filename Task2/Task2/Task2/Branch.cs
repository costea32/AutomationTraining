using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Task2
{
    public class Branch : Container
    {
        public Branch(string name, int behind, int ahead, string url)
        {
            this.name = name;
            this.behind = behind;
            this.ahead = ahead;
            this.url = url;
        }
        
        [JsonProperty("Behind", Order = 3)]
        public int behind { get; set; }

        [JsonProperty("Ahead", Order = 2)]
        public int ahead { get; set; }

        [JsonIgnore]
        public string url { get; set; }

    }
}
