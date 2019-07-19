using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public class MockEmployeeRepository : IEmployeeRepository, IEmployeeList
    {
        private List<Employee> _employeeList;

        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee(){ Id=1, Name="Jame", Email="jamea3222@gmail.com", Department="CSE" },
                new Employee(){ Id=2, Name="Sadia", Email="sadia@gmail.com", Department="EEE" },
                new Employee(){ Id=3, Name="Afrin", Email="afrin@gmail.com", Department= "EEE" }
            };
        }

        public Employee GetEmployee(int id)
        {
            return _employeeList.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }
    }
}
