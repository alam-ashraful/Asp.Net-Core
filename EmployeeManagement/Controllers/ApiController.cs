using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.ExpressionTranslators.Internal;

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

        [Produces("application/json")]
        [HttpGet("search/{nm}")]
        public IActionResult Search(string nm)
        {
            try
            {
                var getResult = _employeeList.GetEmployees()
                    .Where(x => x.Name.Contains(nm) || x.Email.Contains(nm))
                    .Select(p => new
                    {
                        name = p.Name,
                        email = p.Email,
                        id = p.Id
                    })
                    .ToList();
                return Ok(getResult);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}