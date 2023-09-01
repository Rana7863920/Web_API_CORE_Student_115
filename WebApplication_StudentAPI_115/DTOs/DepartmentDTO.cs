﻿using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace WebApplication_StudentAPI_115.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name cannot be emtpy")]
        public string Name { get; set; }
    }
}
