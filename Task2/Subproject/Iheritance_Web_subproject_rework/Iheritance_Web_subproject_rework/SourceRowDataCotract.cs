﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Iheritance_Web_subproject_rework
{
    [DataContract]
    class SourceRowDataContract
    {
        [DataMember]
        string name;

        [DataMember]
        string type;       

        [DataMember]
        string comment;

        [DataMember]
        string last_updated;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }


        public string Last_updated
        {
            get { return last_updated; }
            set { last_updated = value; }
        }

        public SourceRowDataContract(SourceRow sRow)
        {
            this.name = sRow.Name;
            this.type = sRow.Type;
            this.comment = sRow.Comment;
            this.last_updated = sRow.Last_updated;
        }


    }
}
