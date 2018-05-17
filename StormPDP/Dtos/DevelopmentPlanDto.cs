using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using StormPDP.Models;

namespace StormPDP.Dtos
{
    public class DevelopmentPlanDto
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public EmployeeDto Employee { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateCreated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime QuarterlyReviewDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AnnualReviewDate { get; set; }

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
        public int? EmployeeRating { get; set; }

        [Display(Name = "Manager's Rating")]
        public int? ManagerRating { get; set; }

        [Display(Name = "Agreed Rating")]
        public int? AgreedRating { get; set; }

        public virtual ICollection<TrainingPlanDto> TrainingPlans { get; set; }

        public virtual ICollection<Objective> Objectives { get; set; }

    }
}