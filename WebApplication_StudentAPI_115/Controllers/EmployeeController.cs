using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Admin,Employee")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employeeList = await _unitOfWork.Employee.GetAll();
            if (employeeList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(employeeList);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{employeeId:int}")]
        public async Task<IActionResult> GetEmployeeByIdAsync(int employeeId)
        {
            var emp = await _unitOfWork.Employee.GetById(employeeId);
            return Ok(emp);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _unitOfWork.Employee.Add(employee);
            _unitOfWork.Save();
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] Employee employee)
        {
            if (employee == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _unitOfWork.Employee.Update(employee);
            _unitOfWork.Save();
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _unitOfWork.Employee.Find(id);
            if (employee == null) return NotFound("User does not exists... Please check id");
            _unitOfWork.Employee.Delete(employee);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
