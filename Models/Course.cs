using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_najehacademy.Models
{ 
   
    public class Course
    {
        public int ID { get; set; }
      
        public string Name { get; set; }
        public double Price { get; set; }
        public int Hours { get; set; }
        public virtual List<Junction> Junctions { get; set; }
    }
}