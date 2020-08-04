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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
