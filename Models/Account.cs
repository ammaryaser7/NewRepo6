using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc_najehacademy.Models
{
    public class Account
    {
        [Key][ForeignKey("User")]
        public int ID { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Mobile { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        [Required]
        public DateTime birth { get; set; }

        public string  Image { get; set; }

        public virtual User User { get; set; } // For Relationship

    }
}