using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mvc_najehacademy.Models
{
    public class News
    {

        public int ID { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime? Ontime { get;  set; }
    }
}