using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Transactions;
using WebApplication_StudentAPI_115.DTOs;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        //[Authorize(Roles = "Admin,Employee")]
        //[CustomAuthorization]
        [HttpGet]
        public IActionResult GetAllAsync()
        {
            var employeeList = _mapper.Map<List<EmployeeDTO>>(_unitOfWork.Employee.GetAll());
            if (employeeList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employeeList);
            }
        }
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateEmployee([FromQuery]int depId, [FromBody]EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var employeeMap = _mapper.Map<Employee>(employeeDTO);
            if (!_unitOfWork.Employee.CreateEmployee(depId, employeeMap))
            {
                return StatusCode(500, "Something went wrong while saving");
            }
            return Ok("Employee Successfully Created");
        }
        //[Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateEmployee([FromQuery] int newDepId, [FromQuery] int oldDepId, [FromBody] EmployeeDTO employeeDTO)
        {
            if (employeeDTO == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var employeeMap = _mapper.Map<Employee>(employeeDTO);
            if (!_unitOfWork.Employee.UpdateEmployee(newDepId, oldDepId, employeeMap))
            {
                return StatusCode(500, "Something went wrong while saving");
            }
            return Ok("Employee Successfully Updated");
        }
        //[Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _unitOfWork.Employee.Find(id);
            if (employee == null) return NotFound();
            _unitOfWork.Employee.Delete(employee);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
