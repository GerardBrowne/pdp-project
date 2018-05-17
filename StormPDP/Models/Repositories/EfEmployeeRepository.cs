using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StormPDP.ViewModels;

namespace StormPDP.Models.Repositories
{
    public class EfEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();

        public IQueryable<Employee> Employees => _context.Employees.Include(e => e.Manager);

        public Employee SaveEmployee(Employee employee)
        {
            if (employee.Id == 0)
            {
                _context.Employees.Add(employee);
            }
            else
            {
                _context.Entry(employee).State = EntityState.Modified;
            }

            _context.SaveChanges();
            return employee;
        }

        public EmployeeFormViewModel NewEmployee()
        {
            var managers = _context.Managers.ToList();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = new Employee(),
                Managers = managers
            };
            return viewModel;
        }

        public EmployeeFormViewModel EditEmployee(int id)
        {
            var managers = _context.Managers.ToList();
            var employee = _context.Employees.SingleOrDefault(e => e.Id == id);

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee,
                Managers = managers
            };

            return viewModel;
        }
        
        public void Delete(Employee employee)
        {
            _context.Employees.Remove(employee);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}