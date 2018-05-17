using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.Results;
using System.Web.Mvc;
using AutoMapper;
using StormPDP.Models;
using StormPDP.Models.Repositories;
using StormPDP.ViewModels;

namespace StormPDP.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo)
        {
            _employeeRepo = employeeRepo;
        }

        public ViewResult Index()
        {
            var employees = _employeeRepo.Employees.ToList();

            return View(employees);
        }
    

    public ActionResult Details(int id)
        {
            var employee = _employeeRepo.Employees
                .SingleOrDefault(e => e.Id == id);

            if (employee == null)
            {
                return HttpNotFound();
            }

            return View(employee);
        }

        public ActionResult New()
        {
            var viewModel = _employeeRepo.NewEmployee();

            return View("EmployeeForm", viewModel);
        }

        [System.Web.Mvc.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EmployeeFormViewModel()
                {
                    Employee = employee,
                };

                return View("EmployeeForm", viewModel);
            }

            _employeeRepo.SaveEmployee(employee);
           

            return RedirectToAction("Index", "Employee");
        }

        //Edit goes to EmployeeForm
        public ActionResult Edit(int id)
        {
            var employee = _employeeRepo.EditEmployee(id);

            if (employee == null)
                return HttpNotFound();

            return View("EmployeeForm", employee);
        }
    }
}