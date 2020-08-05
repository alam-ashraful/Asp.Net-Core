using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.ViewModels
{
    public class CSVViewModel
    {
        [DisplayName("Upload a csv file")]
        [Required(ErrorMessage ="Please select a csv file with a correct format")]
        public IFormFile filePath { get; set; }
    }
}
