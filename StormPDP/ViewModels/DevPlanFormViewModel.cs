using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormPDP.Models;

namespace StormPDP.ViewModels
{
    public class DevPlanFormViewModel
    {
        public DevelopmentPlan DevelopmentPlan { get; set; }

        public IEnumerable<Employee> Employees { get; set; }

        [Display(Name = "Skill")]
        public int SelectedSkillId { get; set; }

        public List<Skill> SelectedSkillsList { get; set; }

        public IEnumerable<SelectListItem> Skills { get; set; }

        public ICollection<EmployeeSkill> EmployeeSkills { get; set; }

        public EmployeeSkill EmployeeSkill { get; set; }

        public Objective Objective { get; set; }

        public TrainingPlan TrainingPlan { get; set; }
    }
}