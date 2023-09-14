using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public StudentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult GetStudents()
        {
            var students = _unitOfWork.Student.GetAll();
            return Ok(students);
        }
        [HttpPost]
        public IActionResult CreateStudent(Student student)
        {
            if (student == null) return BadRequest();
            if(ModelState.IsValid)
            {
                _unitOfWork.Student.Add(student);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateStudent(Student student)
        {
            if(student == null) return BadRequest();
            if(ModelState.IsValid)
            {
                _unitOfWork.Student.Update(student);
                _unitOfWork.Save();
            }
            return Ok();
        }
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
