using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using StormPDP.ViewModels;

namespace StormPDP.Models.Repositories
{
    public class EfReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Review> Reviews => _context.Reviews.Include(r => r.Employee);

        public ReviewFormViewModel SaveReview(ReviewFormViewModel model)
        {
            if (model.Review.Id == 0)
            {
                _context.Reviews.Add(model.Review);
            }
            else
            {
                _context.Entry(model.Review).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return model;
        }

        public ReviewFormViewModel NewReview()
        {
            var employees = _context.Employees.ToList();
            var viewModel = new ReviewFormViewModel
            {
                Review = new Review(),
                Employees = employees
            };
            
            return viewModel;
        }

        public ReviewFormViewModel EditReview(int id)
        {
            var employees = _context.Employees.ToList();
            var review = _context.Reviews.SingleOrDefault(r => r.Id == id);

            var viewModel = new ReviewFormViewModel
            {
                Employees = employees,
                Review = review
            };

            return viewModel;
        }

        public void Delete(Review review)
        {
            _context.Reviews.Remove(review);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}