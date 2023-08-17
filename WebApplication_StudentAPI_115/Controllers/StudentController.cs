using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WebApplication_StudentAPI_115.Data;
using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }
        [Authorize(Roles = "Admin,Student")]
        //[CustomAuthorization]
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            return Ok(_context.Students.ToList());
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult SaveStudent([FromBody]Student student)
        {
            if (student == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            var studentInDb = _context.Students.ToList().FirstOrDefault(x => x.Email == student.Email);
            if (studentInDb == null)
            {
                _context.Students.Add(student);
                _context.SaveChanges();
            }
            else
            {
                return StatusCode(404, "Email is already registered... Please Check");
            }
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult UpdateStudent([FromBody]Student student)
        {
            if(student == null) return BadRequest();
            if(!ModelState.IsValid) return BadRequest();
            var studentInDb = _context.Students.AsNoTracking().
                FirstOrDefault(x => x.Email == student.Email && x.Id == student.Id);
            var studentX = _context.Students.AsNoTracking().
                FirstOrDefault(x => x.Email == student.Email && x.Id != student.Id);
            if(studentInDb == null && studentX != null)
            {
                return StatusCode(404, "Email is already registered... Please Check");
            }
            else
            {
                _context.Students.Update(student);
                _context.SaveChanges();
            }
            return Ok();
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentInDb = _context.Students.Find(id);
            if (studentInDb == null) return NotFound("User does not exists... Please check id");
            _context.Students.Remove(studentInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
