using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormPDP.Dtos
{
    public class TrainingPlanDto
    {
        [Key]
        public int TrainingId { get; set; }

        public int DevelopmentPlanId { get; set; }

        public string Name { get; set; }

        [Range(0, 5)]
        public int? Competency { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? Timing { get; set; }

        public string Opportunity { get; set; }

        public virtual ICollection<DevelopmentPlanDto> DevelopmentPlans { get; set; }

    }
}