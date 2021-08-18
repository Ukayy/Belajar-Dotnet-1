using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public Guid Id { get; set; }

        [Required]
        public String Name { get; set; }

        [Required]
        public String Position { get; set; }

        [Required]
        public int age { set; get; }

    }
}
