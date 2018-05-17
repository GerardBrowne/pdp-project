using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;
using StormPDP.Controllers;
using StormPDP.Models;
using StormPDP.Models.Repositories;
using StormPDP.ViewModels;

namespace StormPDP.Tests.ControllerTests
{
    [TestFixture]
    public class ReviewControllerTests
    {
        [Test]
        public void ReviewIndexViewContainsListOfReviewModels()
        {
            //Arrange
            var mock = new Mock<IReviewRepository>();

            mock.Setup(d => d.Reviews).Returns(new[]
            {
                new Review { Id = 1, EmployeeId = 2 },
                new Review { Id = 2, EmployeeId = 4 },
                new Review { Id = 3, EmployeeId = 1 }
            }.AsQueryable());

            var controller = new ReviewController(mock.Object);

            //Act
            var actual = (List<Review>)controller.Index().Model;

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<List<Review>>(actual);
        }

        [Test]
        public void ReviewDetailsViewReturnsSingleReviewModel()
        {
            //Arrange
            var mock = new Mock<IReviewRepository>();

            mock.Setup(r => r.Reviews).Returns(new[]
            {
                new Review { Id = 4, EmployeeId = 6 }
            }.AsQueryable());

            var controller = new ReviewController(mock.Object);

            //Act
            var actual = controller.Details(4) as ViewResult;
            var model = actual.Model as Review;

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(4, model.Id);
        }

        [Test]
        public void ReviewNewShouldReturnReviewFormView()
        {
            //Arrange
            var mock = new Mock<IReviewRepository>();
            var controller = new ReviewController(mock.Object);

            //Act
            var actual = controller.New() as ViewResult;

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.ViewName, "ReviewForm");
        }

        [Test]
        public void ReviewSaveShouldSaveReviewModel()
        {
            //Arrange
            var mock = new Mock<IReviewRepository>();
            var controller = new ReviewController(mock.Object);

            var review = new Review
            {
                Id = 2,
                EmployeeId = 5
            };
            var model = new ReviewFormViewModel
            {
                Review = review
            };

            //Act
            var result = controller.Save(model);


            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", ((RedirectToRouteResult)result).RouteValues["action"]);
        }
    }
}
