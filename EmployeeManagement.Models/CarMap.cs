using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeManagement.Models
{
    public sealed class CarMap : ClassMap<Car>
    {
        public CarMap()
        {
            Map(x => x.Manufacturer).Name("Manufacturer");
            Map(x => x.Model).Name("Model");
            Map(x => x.Year).Name("Year");
            Map(x => x.ProducingCountry).Name("Producing Country");
        }
    }
}
