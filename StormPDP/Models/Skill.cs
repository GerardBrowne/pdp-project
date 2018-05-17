using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormPDP.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }

        public string Name { get; set; }

        public virtual ICollection<EmployeeSkill> EmployeeSkills { get; set; }

    }
}