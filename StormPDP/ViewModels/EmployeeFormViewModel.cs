using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormPDP.Models;

namespace StormPDP.ViewModels
{
    public class EmployeeFormViewModel
    {
        public IEnumerable<Manager> Managers { get; set; }

        [Display(Name = "Skill")]
        public int SkillId { get; set; }

        public IEnumerable<SelectListItem> Skills { get; set; }

        //public Skill Skill { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        //public EmployeeSkill EmployeeSkill { get; set; }

        public Employee Employee { get; set; }

        //public DevelopmentPlan DevelopmentPlan { get; set; }
    }
}