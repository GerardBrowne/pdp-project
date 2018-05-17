using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StormPDP.Dtos;

namespace StormPDP.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        public int? StormId { get; set; }

        public string Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Position { get; set; }

        public ManagerDto Manager { get; set; }

        public virtual ICollection<EmployeeSkillDto> EmployeeSkills { get; set; }

    }
}