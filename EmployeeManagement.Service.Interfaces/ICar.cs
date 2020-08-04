using EmployeeManagement.Models;
using EmployeeManagement.Service.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Interfaces
{
    public interface ICar
    {
        IEnumerable<Car> GetCars(bool antrac = false);
        Car GetCar(int id);
        Car Add(Car obj);
        Boolean Delete(int id);
        Car Update(Car obj);
    }
}
