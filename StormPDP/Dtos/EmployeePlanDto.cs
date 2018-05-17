using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StormPDP.Models;

namespace StormPDP.Dtos
{
    public class EmployeePlanDto
    {
        public string Function { get; set; }

        [Display(Name = "Current Certificates")]
        public string CurrentCertification { get; set; }

        [Display(Name = "Ambitions")]
        public string Ambition { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

    }
}