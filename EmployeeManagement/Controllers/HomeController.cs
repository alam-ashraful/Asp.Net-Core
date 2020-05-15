using EmployeeManagement.Models;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
using System.Diagnostics;
using Nancy.Json;
using Microsoft.Web.Mvc;

namespace EmployeeManagement.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeList _employeeList;
        private readonly IHostingEnvironment _hostingEnvironment;

        public HomeController(IEmployeeRepository employeeRepository, IEmployeeList employeeList,
            IHostingEnvironment hostingEnvironment)
        {
            _employeeRepository = employeeRepository;
            _employeeList = employeeList;
            _hostingEnvironment = hostingEnvironment;
        }

        public ViewResult Index(int? id)
        {
            return View(_employeeRepository.GetEmployee(id ?? 3));
        }

        [HttpGet]
        public ViewResult GetAll(int pageNumber = 1, int pageSize = 3)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var empList = _employeeList.GetEmployees(true)
                .Skip(ExcludeRecords)
                .Take(pageSize);
            
            var result = new PagedResult<Employee>
            {
                Data = empList.ToList(),
                TotalItems = _employeeList.GetEmployees().Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(result);
        }

        [HttpGet]
        [Route("[controller]/api/getall")]
        public JsonResult GetAllByApi(int pageNumber = 1, int pageSize = 3)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var empList = _employeeList.GetEmployees(true)
                .Skip(ExcludeRecords)
                .Take(pageSize);

            var result = new PagedResult<Employee>
            {
                Data = empList.ToList(),
                TotalItems = _employeeList.GetEmployees().Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Json(result);
        }

        public ViewResult Details(int? id)
        {
            // check
            throw new Exception("Error in details view");

            Employee employee = _employeeRepository.GetEmployee(id.Value);

            if (employee == null)
            {
                return View("EmployeeNotFound", id.Value);
            }

            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                Employee = employee,
                PageTitle = "Employee Details | By pass"
            };

            return View(homeDetailsViewModel);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeRepository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.Id,
                Name = employee.Name,
                Department = employee.Department,
                Email = employee.Email,
                ExistingPhotoPath = employee.PhotoPath
            };

            return View(employeeEditViewModel);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            Employee employee = _employeeRepository.GetEmployee(model.Id);
            employee.Name = model.Name;
            employee.Email = model.Email;
            employee.Department = model.Department;
            if (model.Photo != null)
            {
                if (model.ExistingPhotoPath != null)
                {
                    System.IO.File.Delete(Path.Combine(_hostingEnvironment.WebRootPath, "images", model.ExistingPhotoPath));
                }
                employee.PhotoPath = ProcessUploadFile(model);
            }

            _employeeRepository.Update(employee);
            return RedirectToAction("Details", new { id = employee.Id });
        }

        public IActionResult Delete(int id)
        {
            if (_employeeRepository.Delete(id))
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
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadFile(model);

                Employee newEmployee = new Employee()
                {
                    Name = model.Name,
                    Department = model.Department,
                    Email = model.Email,
                    PhotoPath = uniqueFileName
                };

                _employeeRepository.Add(newEmployee);
                return RedirectToAction("Details", new { id = newEmployee.Id });
            }

            return View("Create");
        }

        private string ProcessUploadFile(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            //if (model.Photos != null && model.Photos.Count > 0)
            //{
            //    foreach (IFormFile photo in model.Photos)
            //    {
            //        string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
            //        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
            //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            //        photo.CopyTo(new FileStream(filePath, FileMode.Create));
            //    }
            //}
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }
    }
}
