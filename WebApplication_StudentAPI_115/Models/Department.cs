﻿using System.ComponentModel.DataAnnotations;

namespace WebApplication_StudentAPI_115.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
    }
}
