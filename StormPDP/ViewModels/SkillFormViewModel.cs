using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormPDP.Models;

namespace StormPDP.ViewModels
{
    public class SkillFormViewModel
    {
        public IEnumerable<SelectListItem> SkillsList { get; set; }


        public int SelectedSkillId { get; set; }

        public MultiSelectList Skills { get; set; }

        public List<int> SelectedSkills { get; set; }

        public EmployeeSkill EmployeeSkill { get; set; }
    }
}