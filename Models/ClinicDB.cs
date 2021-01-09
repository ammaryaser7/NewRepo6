using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RCCClinic.Models
{
    public class ClinicDB : DbContext
    {
        public ClinicDB() : base("constr") { }

        public DbSet<User> Users { get; set; }
        
       public DbSet<Patient> Patients { get; set; }


    }
}