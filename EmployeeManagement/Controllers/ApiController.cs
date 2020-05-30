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

        [Produces("application/json")]
        [HttpGet("search/{nm}")]
        public async Task<IActionResult> Search(string nm, string em)
        {
            try
            {
                var getResult = _employeeList.GetEmployees()
                    .Where(x => x.Name.Contains(nm))
                    .Select(p => new
                    {
                        name = p.Name
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