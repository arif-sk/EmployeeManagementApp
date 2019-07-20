using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EmployeeManagementApp.Models;
using Microsoft.AspNetCore.Http;

namespace EmployeeManagementApp.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(20, ErrorMessage = "Excede Max length")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Invalid Email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Department is Required")]
        public Dept? Department { get; set; }
        public List<IFormFile> Photos { get; set; }
    }
}
