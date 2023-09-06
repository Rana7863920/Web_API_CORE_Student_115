using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_StudentAPI_115.DTOs;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Models.ViewModels;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetDepartment()
        {
            var departments = _mapper.Map<List<DepartmentDTO>>(_unitOfWork.Department.GetAll());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(departments);
        }
        [HttpPost]
        public IActionResult CreateDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null) return BadRequest();
            if (ModelState.IsValid)
            {
                var departmentMap = _mapper.Map<Department>(departmentDTO);
                _unitOfWork.Department.Add(departmentMap);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateDepartment([FromBody] DepartmentDTO departmentDTO)
        {
            if (departmentDTO == null) return BadRequest();
            if (ModelState.IsValid)
            {
                var departmentMap = _mapper.Map<Department>(departmentDTO);
                _unitOfWork.Department.Update(departmentMap);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpDelete]
        public IActionResult DeleteDepartment(int id)
        {
            var department = _unitOfWork.Department.Find(id);
            if (department == null) return NotFound();
            _unitOfWork.Department.Delete(department);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
