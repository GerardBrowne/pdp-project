using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormPDP.Models;
using StormPDP.ViewModels;

namespace StormPDP.Controllers
{
    public class EmployeeSkillController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeeSkillController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
    }
}