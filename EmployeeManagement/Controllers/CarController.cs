using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cloudscribe.Pagination.Models;
//using System.Web.Helpers;
using EmployeeManagement.Models;
using EmployeeManagement.Service.Interfaces;
using EmployeeManagement.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class CarController : Controller
    {
        private readonly ICar _car;
        public CarController(ICar car)
        {
            _car = car;
        }

        [HttpGet]
        public IActionResult Index(int pageNumber = 1, int pageSize = 3)
        {
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;

            var empList = _car.GetCars(true)
                .Skip(ExcludeRecords)
                .Take(pageSize);

            var result = new PagedResult<Car>
            {
                Data = empList.ToList(),
                TotalItems = _car.GetCars().Count(),
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return View(result);
        }

        [HttpGet]
        public ViewResult Details(int? id)
        {
            Car car = _car.GetCar(id.Value);

            if (car == null)
            {
                return View("EmployeeNotFound", id.Value);
            }

            CarViewModel carViewModel = new CarViewModel()
            {
                Car = car,
                PageTitle = "Car View"
            };

            return View(carViewModel);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Car obj)
        {
            if (ModelState.IsValid)
            {
                Car car = new Car()
                {
                    Manufacturer = obj.Manufacturer,
                    Model = obj.Model,
                    Year = obj.Year,
                    ProducingCountry = obj.ProducingCountry
                };

                _car.Add(car);
                return RedirectToAction("Details", new { id = car.Id });
            }

            return View("Create");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Car car = _car.GetCar(id);

            if (car != null)
            {
                //CarViewModel carViewModel = new CarViewModel();
                //carViewModel.Car = car;
                //carViewModel.PageTitle = "Details view | Edit";
                return View(car);
            }

            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Edit(Car obj)
        {
            //Car car = _car.GetCar(obj.Id);
            //car.Manufacturer = obj.Manufacturer;
            //car.Model = obj.Model;
            //car.ProducingCountry = obj.ProducingCountry;
            //car.Year = obj.Year;

            _car.Update(obj);
            return RedirectToAction("Details", new { id = obj.Id });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (_car.Delete(id))
            {
                return RedirectToAction("index");
            }
            return RedirectToAction("Create");
        }

        [HttpGet]
        public JsonResult CarManufacturer()
        {
            return Json(_car.GetCars());
        }        
    }
}