using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormPDP.Models;
using StormPDP.ViewModels;

namespace StormPDP.Controllers
{
    public class SkillController : Controller
    {
        private ApplicationDbContext _context;

        public SkillController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var skills = _context.Skills.ToList();
            return View(skills);
        }


        public ActionResult New()
        {
            var viewModel = new SkillFormViewModel
            {
                SkillsList = _context.Skills.Select(d => new SelectListItem
                {
                    Text = d.Name,
                    Value = d.SkillId.ToString()
                })
            };
            return View("SkillForm");
        }

        [HttpPost]
        public ActionResult Save(SkillFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("SkillForm");
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Skill");
        }

        public ActionResult Edit(int id)
        {
            var skill = _context.Skills.SingleOrDefault(s => s.SkillId == id);

            if (skill == null)
                return HttpNotFound();

            return View("SkillForm", skill);
        }
    }
}