using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebApplication_StudentAPI_115.Data;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [Authorize(Roles = "Admin,Student")]
        [HttpGet]
        public async Task<IActionResult> GetAllStudent()
        {
            var studentList = _unitOfWork.Student.GetAll();
            if (studentList == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(studentList);
            }
        }
        [Authorize(Roles = "Admin")]
        [HttpGet("{studentId:int}")]
        public async Task<IActionResult> GetStudentById(int studentId)
        {
            var student = await _unitOfWork.Student.GetById(studentId);
            if (student == null) return NotFound();
            else return Ok(student);
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _unitOfWork.Student.Add(student);
            _unitOfWork.Save();
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            if (student == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _unitOfWork.Student.Update(student);
            _unitOfWork.Save();
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]

        public IActionResult DeleteStudent(int id)
        {
            var student = _unitOfWork.Student.Find(id);
            if (student == null) return NotFound();
            _unitOfWork.Student.Delete(student);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
