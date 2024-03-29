﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

namespace WebApplication_StudentAPI_115.Models
{
    public class Employee
    {
        public int Id { get; set; }
        //[Required(ErrorMessage = "Name cannot be emtpy")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Salary cannot be empty")]
        public int Salary { get; set; }
        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
