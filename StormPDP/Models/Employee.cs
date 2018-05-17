using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormPDP.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Display(Name = "Storm ID")]
        public int? StormId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }


        [Display(Name="Manager")]
        public int ManagerId { get; set; }

        public Manager Manager { get; set; }


        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }
    }
}