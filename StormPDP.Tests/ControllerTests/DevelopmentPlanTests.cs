using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Moq;
using StormPDP.Controllers;
using StormPDP.Models;
using StormPDP.Models.Repositories;
using NUnit.Framework;
using StormPDP.ViewModels;
using Assert = NUnit.Framework.Assert;

namespace StormPDP.Tests.ControllerTests
{
    [TestFixture]
    public class DevelopmentPlanTests
    {
        [Test]
        public void DevelopmentPlanIndexViewContainsListOfDevelopmentPlanModel()
        {
            //Arrange
            var mock = new Mock<IDevelopmentPlanRepository>();

            mock.Setup(d => d.DevelopmentPlans).Returns(new[]
            {
                new DevelopmentPlan { Id = 1, EmployeeId = 2 },
                new DevelopmentPlan { Id = 2, EmployeeId = 4 },
                new DevelopmentPlan { Id = 3, EmployeeId = 1 }
            }.AsQueryable());

            var controller = new DevelopmentPlanController(mock.Object);

            //Act
            var actual = (List<DevelopmentPlan>) controller.Index().Model;

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOf<List<DevelopmentPlan>>(actual);
        }

        [Test]
        public void DevelopmentPlanDetailsViewReturnsSingleDevelopmentPlanModel()
        {
            //Arrange
            var mock = new Mock<IDevelopmentPlanRepository>();

            mock.Setup(d => d.DevelopmentPlans).Returns(new[]
            {
                new DevelopmentPlan { Id = 4, EmployeeId = 6 }
            }.AsQueryable());

            var controller = new DevelopmentPlanController(mock.Object);
           
            //Act
            var actual = controller.Details(4) as ViewResult;
            var model = actual.Model as DevelopmentPlan;

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(4, model.Id);
        }

        [Test]
        public void DevelopmentPlanNewShouldReturnDevelopmentPlanFormView()
        {
            //Arrange
            var mock = new Mock<IDevelopmentPlanRepository>();
            var controller = new DevelopmentPlanController(mock.Object);

            //Act
            var actual = controller.New() as ViewResult;

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.ViewName, "DevelopmentPlanForm");
        }

        [Test]
        public void DevelopmentPlanSaveShouldSaveDevelopmentPlanModel()
        {
            //Arrange
            var mock = new Mock<IDevelopmentPlanRepository>();
            var controller = new DevelopmentPlanController(mock.Object);

            var devPlan = new DevelopmentPlan
            {
                Id = 2,
                EmployeeId = 5
            };
            var model = new DevPlanFormViewModel
            {
                DevelopmentPlan = devPlan
            };

            //Act
            var result = controller.Save(model);
            

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", ((RedirectToRouteResult)result).RouteValues["action"]);
        }
    }
}
