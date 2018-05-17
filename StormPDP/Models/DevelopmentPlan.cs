using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormPDP.Models
{
    public class DevelopmentPlan
    {
        public int Id { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        [DataType(DataType.Date)]
        public DateTime? QuarterlyReviewDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? AnnualReviewDate { get; set; }

        [Display(Name = "Current Role")]
        public string CurrentRole { get; set; }

        public string Function { get; set; }

        [Display(Name = "Current Certificates")]
        public string CurrentCertification { get; set; }
  
        [Display(Name = "Ambitions")]
        public string Ambition { get; set; }

        [Display(Name = "Comments")]
        public string Comment { get; set; }

        [Display(Name = "What Can Storm do to assist this")]
        public string StormHelp { get; set; }

        [Display(Name = "Employee's Comments")]
        public string EmployeeComment { get; set; }

        [Display(Name = "Manager's Comments")]
        public string ManagerComment { get; set; }

        [Display(Name = "Employee's Rating")]
        [Range(0, 5)]
        public int? EmployeeRating { get; set; }

        [Display(Name = "Manager's Rating")]
        [Range(0, 5)]
        public int? ManagerRating { get; set; }

        [Display(Name = "Agreed Rating")]
        [Range(0, 5)]

        public int? AgreedRating { get; set; }

        public Employee Employee { get; set; }

        public List<Objective> Objectives { get; set; }

        public List<TrainingPlan> TrainingPlans { get; set; }

        public DevelopmentPlan()
        {
            DateCreated = DateTime.Today;
            QuarterlyReviewDate = DateTime.Today.AddMonths(3);
            AnnualReviewDate = DateTime.Today.AddMonths(12);

            Objectives = new List<Objective>();
            TrainingPlans = new List<TrainingPlan>();
        }
    }
}