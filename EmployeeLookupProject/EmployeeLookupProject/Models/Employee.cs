using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeLookupProject.Models
{
    public class Employee
    {
        public Employee()
        {
        }

        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string Hobbies { get; set; }
        public string Picture { get; set; }
    }
}