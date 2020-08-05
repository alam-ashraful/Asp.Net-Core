using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagement.Models;
using EmployeeManagement.Service.Interfaces;
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
        private readonly ICar _car;
        public ApiController(IEmployeeList employeeList, ICar car)
        {
            _employeeList = employeeList;
            _car = car;
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

        [Produces("application/json")]
        [HttpGet("search-car/{nm}")]
        public IActionResult SearchByCarDetails(string nm)
        {
            try
            {
                var rs = _car.GetCars()
                    .Where(x => x.Manufacturer.ToLower().Contains(nm.ToLower())
                        || x.Model.ToLower().Contains(nm.ToLower())
                        || x.Year.ToLower().Contains(nm.ToLower()) 
                        || x.ProducingCountry.ToLower().Contains(nm.ToLower()))
                    .Select(p => new
                    {
                        manufacturer = p.Manufacturer,
                        model = p.Model,
                        year = p.Year,
                        producingCountry = p.ProducingCountry,
                        id = p.Id
                    })
                    .ToList();
                return Ok(rs);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}