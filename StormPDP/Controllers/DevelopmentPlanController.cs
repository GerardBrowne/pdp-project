using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using StormPDP.Models;
using StormPDP.Models.Repositories;
using StormPDP.ViewModels;

namespace StormPDP.Controllers
{
    public class DevelopmentPlanController : Controller
    {
        private readonly IDevelopmentPlanRepository _developmentPlanRepo;

        public DevelopmentPlanController(IDevelopmentPlanRepository developmentPlanRepo)
        {
            _developmentPlanRepo = developmentPlanRepo;
        }

        public ViewResult Index()
        {
            var devPlans = _developmentPlanRepo.DevelopmentPlans.ToList();

            return View(devPlans);
        }

        public ActionResult Details(int id)
        {
            var devPlan = _developmentPlanRepo.DevelopmentPlans
                .SingleOrDefault(d => d.Id == id);

            if (devPlan == null)
            {
                return HttpNotFound();
            }
                
            return View(devPlan);
        }

        public ActionResult New()
        {
            var viewModel = _developmentPlanRepo.NewDevelopmentPlan();

            return View("DevPlanForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(DevPlanFormViewModel model)
        {
            if (!ModelState.IsValid)
            {

                var viewModel = _developmentPlanRepo.NewDevelopmentPlan();
                
                return View("DevPlanForm", viewModel);
            }

            _developmentPlanRepo.SaveDevelopmentPlan(model);

            return RedirectToAction("Index", "DevelopmentPlan");
        }

        public ActionResult Edit(int id)
        {
            var developmentPlan = _developmentPlanRepo.EditDevelopmentPlan(id);

            if (developmentPlan == null)
                return HttpNotFound();

            return View("DevPlanForm", developmentPlan);
        }

        public ActionResult ExportDetails(int id)
        {
            var cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
            var devPlan = _developmentPlanRepo.DevelopmentPlans
                .SingleOrDefault(d => d.Id == id);
            return new ActionAsPdf("Details", devPlan)
            {
                FileName = "dplan.pdf",
                FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName,
                Cookies = cookies
            };

        }

        
    }
}