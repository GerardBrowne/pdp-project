using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StormPDP.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateCreated { get; set; }

        [Display(Name = "Employee")]
        public int EmployeeId { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Job Knowledge")]
        [Range(0, 5)]
        public int? JobKnowledge { get; set; }

        [Display(Name = "Quality of Work")]
        [Range(0, 5)]
        public int? WorkQuality { get; set; }

        [Display(Name = "Attendance/Punctuality")]
        [Range(0, 5)]
        public int? Attendance { get; set; }

        [Range(0, 5)]
        public int? Initiative { get; set; }

        [Range(0, 5)]
        public int? Communication { get; set; }

        [Range(0, 5)]
        public int? Dependability { get; set; }

        [Display(Name = "Overall Rating")]
        [Range(0, 5)]
        public int? OverallRating { get; set; }

        [Display(Name = "Summary")]
        public string Comment { get; set; }

        public string JobKnowledgeComment { get; set; }

        public string WorkQualityComment { get; set; }

        public string AttendanceComment { get; set; }

        public string InitiativeComment { get; set; }

        public string CommunicationComment { get; set; }

        public string DependabilityComment { get; set; }

        public Review()
        {
            DateCreated = DateTime.Today;
            OverallRating = (
                (JobKnowledge + WorkQuality + Attendance + Initiative + Communication + Dependability) /
                             6);
        }
    }
}