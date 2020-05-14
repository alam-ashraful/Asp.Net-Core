using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmployeeManagement.Service.Infrastructures
{
    public class SQLEmployeeRepository : IEmployeeRepository, IEmployeeList
    {
        private readonly AppDbContext _appDbContext;

        public SQLEmployeeRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Employee Add(Employee employee)
        {
            if (employee != null)
            {
                _appDbContext.Employees.Add(employee);
                _appDbContext.SaveChanges();
            }
            return employee;
        }

        public Boolean Delete(int id)
        {
            var employee =  _appDbContext.Employees.Find(id);
            if (employee != null)
            {
                _appDbContext.Employees.Remove(employee);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Employee GetEmployee(int id)
        {
            return _appDbContext.Employees.Find(id);
        }

        public IEnumerable<Employee> GetEmployees(bool antrac = false)
        {
            if (antrac)
                return _appDbContext.Employees.AsNoTracking();
            else
                return _appDbContext.Employees;
        }

        public Employee Update(Employee employeeChanges)
        {
            var employee = _appDbContext.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _appDbContext.SaveChanges();

            return employeeChanges;
        }
    }
}
