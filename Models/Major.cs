using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace mvc_najehacademy.Models
{
    [DataContract]
    public class Major
    {
        [DataMember]
        public int ID { get; set; } // PK

        [DataMember]
        public string Title { get; set; }

        [DataMember]
        public virtual List<User> Users { get; set; }
    }
}