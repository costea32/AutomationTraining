﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Task2
{
    public class Folder : Container
    {
        public Folder(string name, string comment, string lastUpdated)
        {
            this.name = name;
            this.comment = comment;
            this.lastUpdated = lastUpdated;
        }

        [JsonProperty("Type", Order = 2)]
        public string type = "Folder";

        [JsonProperty("Comment", Order = 3)]
        public string comment { get; set; }

        [JsonProperty("LastUpdated", Order = 4)]
        public string lastUpdated { get; set; }
    }
}
