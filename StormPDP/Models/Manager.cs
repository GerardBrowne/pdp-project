using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StormPDP.Models
{
    public class Manager
    {
        public int Id { get; set; }

        [Display(Name="Storm ID")]
        public int StormId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Email { get; set; }
    }
}