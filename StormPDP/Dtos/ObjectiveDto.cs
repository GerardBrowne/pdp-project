using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StormPDP.Dtos
{
    public class ObjectiveDto
    {
        public int ObjectiveId { get; set; }

        public int DevelopmentPlanId { get; set; }

        public string Name { get; set; }

        [Range(0, 5)]
        public int? Competency { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Timing { get; set; }

        public bool IsAchieved { get; set; }

        public virtual ICollection<DevelopmentPlanDto> DevelopmentPlans { get; set; }

    }
}