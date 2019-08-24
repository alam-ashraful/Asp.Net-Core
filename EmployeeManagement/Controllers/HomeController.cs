using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeList _employeeList;

        public HomeController(IEmployeeRepository employeeRepository, IEmployeeList employeeList)
        {
            _employeeRepository = employeeRepository;
            _employeeList = employeeList;
        }

        public ViewResult Index(int? id)
        {
            return View(_employeeRepository.GetEmployee(id ?? 3));
        }

        public ViewResult GetAll()
        {
            return View(_employeeList.GetEmployees());
        }

        public ViewResult Details(int? id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = _employeeList.GetEmployees().FirstOrDefault(x => x.Id == (id ?? 3)),
                PageTitle = "Employee Details | By pass"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View(_employeeRepository.GetEmployee(id));
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            _employeeRepository.Update(employee);
            return RedirectToAction("Details", new { id = employee.Id });
        }

        public IActionResult Delete(int id)
        {
            if(_employeeRepository.Delete(id))
            {
                return RedirectToAction("GetAll");
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                Employee newEmployee = _employeeRepository.Add(employee);
                //return RedirectToAction("Details", new { id = newEmployee.Id });
            }

            return View("Create");
        }
    }
}
