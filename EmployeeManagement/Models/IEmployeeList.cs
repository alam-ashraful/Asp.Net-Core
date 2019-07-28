﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Models
{
    public interface IEmployeeList
    {
        IEnumerable<Employee> GetEmployees();
        Employee Add(Employee employee);
    }
}
