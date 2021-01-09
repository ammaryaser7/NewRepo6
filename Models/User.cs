using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RCCClinic.Models
{
    public class User
    {
        
        public int ID { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z0-9_\.+]+@(live|hotmail|gmail)(\.com)", ErrorMessage = "Should be live, hotmail or gmail")]
        [Index(IsUnique = true)]
        [MaxLength(30)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Do not match")]
        //[NotMapped]
        public string Confirm { get; set; }



    }
}