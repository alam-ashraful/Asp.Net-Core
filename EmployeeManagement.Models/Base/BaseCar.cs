using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Models.Base
{
    public class BaseCar
    {
        [Key,
            DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please provide a manufacturer name")]
        public string Manufacturer { get; set; }
        [Required(ErrorMessage = "Please provide a model name")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Please provide year")]
        public string Year { get; set; }
        [Required(ErrorMessage = "Please provide a country name"),
            DisplayName("Producing country")]
        public string ProducingCountry { get; set; }
    }
}
