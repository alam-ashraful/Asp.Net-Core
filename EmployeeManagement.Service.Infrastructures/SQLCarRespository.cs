using EmployeeManagement.DataAccess;
using EmployeeManagement.Models;
using EmployeeManagement.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Service.Infrastructures
{
    public class SQLCarRespository : ICar
    {
        private readonly AppDbContext _appDbContext;
        public SQLCarRespository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public Car Add(Car obj)
        {
            if (obj != null)
            {
                _appDbContext.Cars.Add(obj);
                _appDbContext.SaveChanges();
            }

            return obj;
        }

        public bool Delete(int id)
        {
            var car = _appDbContext.Cars.Find(id);

            if (car != null)
            {
                _appDbContext.Cars.Remove(car);
                _appDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public Car GetCar(int id)
        {
            return _appDbContext.Cars.Find(id);
        }

        public IEnumerable<Car> GetCars(bool antrac = false)
        {
            if (antrac)
                return _appDbContext.Cars.AsNoTracking();
            else
                return _appDbContext.Cars;
        }

        public Car Update(Car obj)
        {
            var car = _appDbContext.Cars.Attach(obj);
            car.State = EntityState.Modified;
            _appDbContext.SaveChanges();

            return obj;
        }
    }
}
