using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Transactions;
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
        //[CustomAuthorization]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var employeeList = _unitOfWork.Employee.GetAll();
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
        public IActionResult CreateEmployee([FromBody] List<Employee> employees)
        {
            if (employees == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {

                foreach (var emp in employees)
                {
                    if(emp.Name == "")
                    {
                        throw new Exception("Name cannot be empty");
                    }
                    _unitOfWork.Employee.Add(emp);
                    _unitOfWork.Save();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return StatusCode(404, ex.Message);
            }

            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateEmployee([FromBody] List<Employee> employees)
        {
            if (employees == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {

                foreach (var emp in employees)
                {
                    if (emp.Name == "")
                    {
                        throw new Exception("Name cannot be empty");
                    }
                    _unitOfWork.Employee.Update(emp);
                    _unitOfWork.Save();
                }
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return StatusCode(404, ex.Message);
            }
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public IActionResult DeleteEmployee(int[] IDs)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                foreach (var id in IDs)
                {
                    var employee = _unitOfWork.Employee.Find(id);
                    //if (employee == null) return NotFound("User does not exists... Please check id");
                    _unitOfWork.Employee.Delete(employee);
                    _unitOfWork.Save();
                }
                transaction.Commit();
            }
            catch(Exception ex) 
            { 
                transaction.Rollback();
                return StatusCode(404, ex.Message);
            }
            
            return Ok();
        }
    }
}
