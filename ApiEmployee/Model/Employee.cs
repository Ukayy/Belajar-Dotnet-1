using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiEmployee.Model
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can Only be 50 character long")]
        public String Name { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Name can Only be 50 character long")]
        public String Position { get; set; }

        [Required]
        public int age { set; get; }
    }
}
