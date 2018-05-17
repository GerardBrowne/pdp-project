using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormPDP.Dtos
{
    public class EmployeeSkillDto
    {
        public int EmployeeId { get; set; }

        public int SkillId { get; set; }

        [Display(Name="Current/Desired")]
        public bool IsCurrent { get; set; }

        [Display(Name="Tech/Non-Technical")]
        public bool IsTechnical { get; set; }
        
    }
}