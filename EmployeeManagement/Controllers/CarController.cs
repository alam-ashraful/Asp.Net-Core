using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Helpers;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    public class CarController : Controller
    {
        public IActionResult Index()
        {
            List<Car> cars = new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Manufacturer = "BMW",
                    Model = "Isetta",
                    Year = "1955",
                    ProducingCountry = "Germany"
                },
                new Car()
                {
                    Id = 2,
                    Manufacturer = "Kia",
                    Model = "Picanto",
                    Year = "2004",
                    ProducingCountry = "South Korea"
                }
            };

            return View(cars);
        }

        [HttpGet]
        public JsonResult CarManufacturer()
        {
            List<Car> cars = new List<Car>()
            {
                new Car()
                {
                    Id = 1,
                    Manufacturer = "BMW",
                    Model = "Isetta",
                    Year = "1955",
                    ProducingCountry = "Germany"
                },
                new Car()
                {
                    Id = 2,
                    Manufacturer = "Kia",
                    Model = "Picanto",
                    Year = "2004",
                    ProducingCountry = "South Korea"
                },
                new Car()
                {
                    Id = 3,
                    Manufacturer = "Kouhei",
                    Model = "Picanto",
                    Year = "1001",
                    ProducingCountry = "Russia"
                },
                new Car()
                {
                    Id = 4,
                    Manufacturer = "Yamaha",
                    Model = "XR2",
                    Year = "2015",
                    ProducingCountry = "Japan"
                },
                new Car()
                {
                    Id = 5,
                    Manufacturer = "Yamaha",
                    Model = "XR2",
                    Year = "2005",
                    ProducingCountry = "Japan"
                }
            };

            return Json(cars);
        }
    }
}