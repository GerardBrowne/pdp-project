using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using StormPDP.Models;

namespace StormPDP.ViewModels
{
    public class ReviewFormViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }

        public Employee Employee { get; set; }

        public Review Review { get; set; }

       

    }
}