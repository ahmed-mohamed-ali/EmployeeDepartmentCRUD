using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HorizonsTask.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string DepartmentName { get; set; }
        [JsonIgnore]
        public virtual ICollection<Employee> Employees { get; set; }
        = new HashSet<Employee>();
    }
}