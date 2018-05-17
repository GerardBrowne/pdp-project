using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormPDP.Models;

namespace StormPDP.ViewModels
{
    public class EmployeeSkillViewModel
    {
        public EmployeeSkill EmployeeSkill { get; set; }

        public Employee Employee { get; set; }

        public Skill Skill { get; set; }

        [Display(Name = "Skill")]
        public int SelectedSkillId { get; set; }

        public List<MultiSelectList> SelectedSkillsList { get; set; }

        public IEnumerable<SelectListItem> Skills { get; set; }
    }
}