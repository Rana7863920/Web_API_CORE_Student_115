﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be emtpy")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Address cannot be empty")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Salary cannot be empty")]
        public int Salary { get; set; }
    }
}
