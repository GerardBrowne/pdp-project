using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StormPDP.Dtos
{
    public class SkillDto
    {
        public int SkillId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<EmployeeDto> Employees { get; set; }
        public virtual ICollection<EmployeeSkillDto> EmployeeSkills { get; set; }
    }
}