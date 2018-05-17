using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StormPDP.Models
{
    public class EmployeeSkill
    {
        public int EmployeeId { get; set; }

        public int SkillId { get; set; }

        [HiddenInput]
        public bool IsTechnical { get; set; }

        [HiddenInput]
        public bool IsCurrent { get; set; }

        public Employee Employee { get; set; }

        public Skill Skill { get; set; }

    }
}