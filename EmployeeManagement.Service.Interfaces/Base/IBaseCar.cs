using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Interfaces.Base
{
    public interface IBaseCar<T>
    {
        IEnumerable<T> GetCars(bool antrac = false);
        T GetCar(int id);
        T Add(T obj);
        Boolean Delete(int id);
        T Update(T obj);
    }
}
