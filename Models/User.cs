using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mvc_najehacademy.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"[a-zA-Z0-9_\.+]+@(live|hotmail|gmail)(\.com|\.om)",
         ErrorMessage ="Should be live, hotmail or gmail")]
        [Index(IsUnique =true)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage ="Required!")]
        [DataType(DataType.Password)]
        [StringLength(20,ErrorMessage ="Length should be between 3 and 20",MinimumLength =3)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [StringLength(20, MinimumLength = 3)]
        public string  Confirm { get; set; }
        public virtual Account Account { get; set; }


        public int? MajorID { get; set; } // FK 
        public virtual Major Major { get; set; } // Connect relationship as 1 to many

        public virtual List<Junction> Junctions { get; set; }

        public Guid? RoleRoleID { get; set; }

        public virtual Role Role { get; set; } 
    }
}