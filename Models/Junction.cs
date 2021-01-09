using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_najehacademy.Models
{
    public class Junction
    {
        public int ID { get; set; }

        public int? UserID { get; set; }

        public int? CourseID { get; set; }

        public virtual Course Course { get; set; }
        public virtual User User { get; set; }



    }
}