using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StormPDP.ViewModels;

namespace StormPDP.Models.Repositories
{
    public interface IEmployeeRepository
    {
        IQueryable<Employee> Employees { get; }

        Employee SaveEmployee(Employee employee);

        EmployeeFormViewModel NewEmployee();

        EmployeeFormViewModel EditEmployee(int id);

        void Delete(Employee employee);

        void Dispose();
    }
}
