using EmployeeManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class CarViewModel : Car
    {
        public Car Car;
        public string PageTitle { get; set; }
    }
}
