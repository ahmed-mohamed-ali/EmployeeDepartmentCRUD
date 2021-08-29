using System;
using System.Data.Entity;
using System.Linq;

namespace HorizonsTask.Models
{
    public class HorizonsContext : DbContext
    {
       
        public HorizonsContext()
            : base("name=HorizonsContext")
        {
        }

    

         public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
    }

   
}