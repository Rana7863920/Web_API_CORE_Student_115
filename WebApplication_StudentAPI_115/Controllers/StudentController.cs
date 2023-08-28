using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
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
        public IActionResult CreateStudent([FromBody] List<Student> students)
        {
            if (students == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                foreach (var student in students)
                {
                    _unitOfWork.Student.Add(student);
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
        public IActionResult UpdateStudent([FromBody] List<Student> students)
        {
            if (students == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                foreach (var student in students)
                {
                    _unitOfWork.Student.Update(student);
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

        public IActionResult DeleteStudent(int[] IDs)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                foreach (var id in IDs)
                {
                    var student = _unitOfWork.Student.Find(id);
                    if (student == null) return NotFound();
                    _unitOfWork.Student.Delete(student);
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
    }
}
