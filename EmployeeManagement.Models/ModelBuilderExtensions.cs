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
            modelBuilder.Entity<Employee>().HasData(
                new Employee()
                {
                    Id = 1,
                    Name = "A1xFcDM",
                    Department = Dept.MMC,
                    Email = "4vcgM@on.in",
                    Password = ""
                },
                new Employee()
                {
                    Id = 2,
                    Name = "A1xFcDMe",
                    Department = Dept.BBA,
                    Email = "4vcgMe@on.in",
                    Password = ""
                }
            );
        }
    }
}
