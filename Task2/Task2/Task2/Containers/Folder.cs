﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using Task2.Selenium;

namespace Task2
{
    [DataContract(Name = "Folder")]
    public class Folder : Container
    {
        public Folder(string name, string comment, string lastUpdated, string url)
        {
            this.name = name;
            this.comment = comment;
            this.lastUpdated = lastUpdated;
            this.url = url;
        }

        [DataMember(Name = "Type", Order = 2)]
        public string type { get 
        {
            int value = (int)RowType.Folder;
            string description = Enumerations.GetEnumDescription((RowType)value);
            return description;
        } 
            set { }
        }

        [DataMember(Name = "Comment", Order = 3)]
        public string comment { get; set; }

        [DataMember(Name = "LastUpdated", Order = 4)]
        public string lastUpdated { get; set; }
    }
}
