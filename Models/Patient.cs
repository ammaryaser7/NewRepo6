using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RCCClinic.Models
{
    public class Patient
    {

        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Mobile { get; set; }

      
        public string CC { get; set; }


        public string Gender { get; set; }

        [Required]
        public int age { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:yyyy-MM-dd}")]
        public DateTime BookedOn { get; set; }

       
        public bool Smoking  { get; set; }

        public bool Allergies { get; set; }

     
        public bool DM { get; set; }

    
        public bool Medication { get; set; }

        public bool HTN { get; set; }


        public bool Pain { get; set; }

        public bool Alcohol { get; set; }

        public string DoctorsNote { get; set; }
        
        public string Imagefile { get; set; }



    }
}