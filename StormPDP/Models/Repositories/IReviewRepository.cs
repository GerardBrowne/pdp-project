using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StormPDP.ViewModels;

namespace StormPDP.Models.Repositories
{
    public interface IReviewRepository
    {
        IQueryable<Review> Reviews { get; }

        ReviewFormViewModel SaveReview(ReviewFormViewModel model);

        ReviewFormViewModel NewReview();

        ReviewFormViewModel EditReview(int id);

        void Delete(Review review);

        void Dispose();
    }
}
