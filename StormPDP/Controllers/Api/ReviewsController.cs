using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using AutoMapper;
using StormPDP.Dtos;
using StormPDP.Models;

namespace StormPDP.Controllers.Api
{
    public class ReviewsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReviewsController()
        {
            _context = new ApplicationDbContext();
        }

        //GET /api/reviews/
        public IEnumerable<Review> GetReviews()
        {
            return _context.Reviews
                .Include(r => r.Employee)
                .ToList();
        }

        //GET /api/reviews/1
        public IHttpActionResult GetReview(int id)
        {
            var review = _context.Reviews.SingleOrDefault(m => m.Id == id);

            if (review == null)
                return NotFound();

            return Ok(review);
        }

        //POST /api/reviews/1
        [System.Web.Mvc.HttpPost]
        public IHttpActionResult CreateReview(Review review)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var newReview = new Review();
            _context.Reviews.Add(newReview);
            _context.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + review.Id), review);
        }

        //PUT /api/reviews/1
        [System.Web.Mvc.HttpPut]
        public void UpdateReview(int id, Review review)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var reviewInDb = _context.Reviews.SingleOrDefault(m => m.Id == id);

            if (reviewInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

           

            _context.SaveChanges();
        }

        //DELETE /api/reviews/1
        [System.Web.Mvc.HttpDelete]
        public void DeleteReview(int id)
        {
            var reviewInDb = _context.Reviews.SingleOrDefault(m => m.Id == id);

            if (reviewInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            _context.Reviews.Remove(reviewInDb);
            _context.SaveChanges();
        }
    }
}