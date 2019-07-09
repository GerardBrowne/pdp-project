using System;
using System.ComponentModel.DataAnnotations;

namespace StormPDP.Models
{
    public class TrainingPlan
    {
        [Key]
        public int TrainingId { get; set; }

        public int DevelopmentPlanId { get; set; }

        public string Name { get; set; }

        [Range(0, 5)]
        public int? Competency { get; set; }

        public DateTime? Timing { get; set; }

        public string Opportunity { get; set; }
    }
}