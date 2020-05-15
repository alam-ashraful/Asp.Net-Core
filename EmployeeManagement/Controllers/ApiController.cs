using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly IEmployeeList _employeeList;
        public ApiController(IEmployeeList employeeList)
        {
            _employeeList = employeeList;
        }

        [HttpGet]
        [Route("getall")]
        public IEnumerable<Employee> GetAll()
        {
            var empList = _employeeList.GetEmployees(true);
            return empList;
        }
    }
}