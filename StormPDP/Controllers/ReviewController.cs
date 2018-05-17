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
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepo;

        public ReviewController(IReviewRepository reviewRepo)
        {
            _reviewRepo = reviewRepo;
        }

        // GET: Review
        public ViewResult Index()
        {
            var reviews = _reviewRepo.Reviews
                .ToList();
            return View(reviews);
        }

        public ActionResult Details(int id)
        {
            var review = _reviewRepo.Reviews
                .SingleOrDefault(r => r.Id == id);

            if (review == null)
            {
                return HttpNotFound();
            }
                
            return View(review);
        }

        public ActionResult New()
        {

            var revFormViewModel = _reviewRepo.NewReview();

            return View("ReviewForm", revFormViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(ReviewFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = _reviewRepo.NewReview();

                return View("ReviewForm", viewModel);
            }

            _reviewRepo.SaveReview(model);

            return RedirectToAction("Index", "Review");
        }

        public ActionResult Edit(int id)
        {
            var review = _reviewRepo.EditReview(id);

            if (review == null)
                return HttpNotFound();

            return View("ReviewForm", review);
        }

        public ActionResult ExportDetails(int id)
        {
            var cookies = Request.Cookies.AllKeys.ToDictionary(k => k, k => Request.Cookies[k].Value);
            var review = _reviewRepo.Reviews
                .SingleOrDefault(d => d.Id == id);
            return new ActionAsPdf("Details", review)
            {
                FileName = "review.pdf",
                FormsAuthenticationCookieName = System.Web.Security.FormsAuthentication.FormsCookieName,
                Cookies = cookies
            };

        }

       
    }
}