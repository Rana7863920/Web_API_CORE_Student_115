﻿using AutoMapper;
using WebApplication_StudentAPI_115.DTOs;
using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Helper
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();
            CreateMap<Company, CompanyDTO>();
            CreateMap<CompanyDTO, Company>();
            CreateMap<Blog, BlogDTO>();
            CreateMap<BlogDTO, Blog>();
            CreateMap<Post, PostDTO>();
            CreateMap<PostDTO, Post>();
        }
    }
}
