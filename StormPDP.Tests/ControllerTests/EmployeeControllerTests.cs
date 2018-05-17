using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using StormPDP.Controllers;
using StormPDP.Models;
using StormPDP.Models.Repositories;
using NUnit.Framework;
using Moq;
using Assert = NUnit.Framework.Assert;
using RedirectToRouteResult = System.Web.Mvc.RedirectToRouteResult;

namespace StormPDP.Tests.ControllerTests
{
    [TestFixture]
    public class EmployeeControllerTests
    {
        [Test]
        public void EmployeeIndexViewContainsListOfEmployeeModel()
        {
            //Arrange
            var mock = new Mock<IEmployeeRepository>();

            mock.Setup(e => e.Employees).Returns(new[]
            {
                new Employee {Id = 1, Name = "AA", ManagerId = 2},
                new Employee {Id = 2, Name = "BB", ManagerId = 1},
                new Employee {Id = 3, Name = "CC", ManagerId = 3}
            }.AsQueryable());

            var controller = new EmployeeController(mock.Object);

            //Act
            var actual = (List<Employee>) controller.Index().Model;

            //Assert
            Assert.IsInstanceOf<List<Employee>>(actual);
        }

        [Test]
        public void EmployeeDetailsViewReturnsSingleEmployeeModel()
        {
            //Arrange
            var mock = new Mock<IEmployeeRepository>();

            mock.Setup(e => e.Employees).Returns(new[]
            {
                new Employee {Id = 5, Name = "DD", ManagerId = 4}
            }.AsQueryable());

            var controller = new EmployeeController(mock.Object);

            //Act
            if (!(controller.Details(5) is ViewResult actual)) return;
            var model = actual.Model as Employee;

            //Assert
            Assert.IsNotNull(actual);
            Assert.IsNotNull(model);
            Assert.AreEqual(5, model.Id);
        }

        [Test]
        public void EmployeeNewShouldReturnEmployeeFormView()
        {
            //Arrange
            var mock = new Mock<IEmployeeRepository>();
            var controller = new EmployeeController(mock.Object);

            //Act
            var actual = controller.New() as ViewResult;

            //Assert
            Assert.IsNotNull(actual);
            Assert.AreEqual(actual.ViewName, "EmployeeForm");
        }

        [Test]
        public void EmployeeSaveShouldSaveEmployeeModel()
        {
            //Arrange
            var mock = new Mock<IEmployeeRepository>();
            var controller = new EmployeeController(mock.Object);

            var employee = new Employee
            {
                Id = 4,
                ManagerId = 1
            };
            
            //Act
            var result = controller.Save(employee);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Index", ((RedirectToRouteResult) result).RouteValues["action"]);
        }
    }
}
