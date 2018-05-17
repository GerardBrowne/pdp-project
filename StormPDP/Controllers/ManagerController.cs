using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormPDP.Models;
using StormPDP.ViewModels;

namespace StormPDP.Controllers
{
    public class ManagerController : Controller
    {
        private ApplicationDbContext _context;

        public ManagerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new ManagerFormViewModel();
            return View("ManagerForm", viewModel);
        }

        public ViewResult Index()
        {
            var managers = _context.Managers.ToList();

            return View(managers);
        }

        public ActionResult Details(int id)
        {
            var manager = _context.Managers.SingleOrDefault(e => e.Id == id);
            if (manager == null)
            {
                return HttpNotFound();
            }

            return View(manager);
        }

        [HttpPost]
        public ActionResult Save(Manager manager)
        {
            if (manager.Id == 0)
                _context.Managers.Add(manager);
            else
            {
                var managerInDb = _context.Managers.Single(c => c.Id == manager.Id);

                managerInDb.StormId = manager.StormId;
                managerInDb.Name = manager.Name;
                managerInDb.Email = manager.Email;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Manager");
        }

        public ActionResult Edit(int id)
        {
            var manager = _context.Managers.SingleOrDefault(e => e.Id == id);

            if (manager == null)
                return HttpNotFound();

            var viewModel = new ManagerFormViewModel()
            {
                Manager = manager
            };
            return View("ManagerForm", viewModel);
        }
    }
}