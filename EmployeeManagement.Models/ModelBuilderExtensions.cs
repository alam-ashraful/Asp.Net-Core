using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Employee>().HasData(
            //    new Employee()
            //    {
            //        Id = 1,
            //        Name = "A1xFcDM",
            //        Department = Dept.MMC,
            //        Email = "4vcgM@on.in",
            //        Password = ""
            //    },
            //    new Employee()
            //    {
            //        Id = 2,
            //        Name = "A1xFcDMe",
            //        Department = Dept.BBA,
            //        Email = "4vcgMe@on.in",
            //        Password = ""
            //    }
            //);

            modelBuilder.Entity<Car>().HasData(
                new Car()
                {
                    Id = 1,
                    Manufacturer = "Dummy 1",
                    Model = "Dummy Model 2",
                    Year = "2000",
                    ProducingCountry = "BD"
                },
                new Car()
                {
                    Id = 2,
                    Manufacturer = "Dummy 2",
                    Model = "Dummy model 2",
                    Year = "2001",
                    ProducingCountry = "Japan"
                }
            );
        }
    }
}
