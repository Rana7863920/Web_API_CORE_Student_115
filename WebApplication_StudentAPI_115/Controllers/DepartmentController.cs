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
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
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
        public IActionResult CreateDepartment([FromQuery]int empId, [FromBody]DepartmentDTO departmentCreate)
        {
            if(departmentCreate == null) return BadRequest(ModelState);

            var department = _unitOfWork.Department.FirstorDefault(x => x.Name == departmentCreate.Name);
            if(department != null)
            {
                ModelState.AddModelError("", "Department already exists");
                return StatusCode(404, ModelState);
            }

            if(!ModelState.IsValid) return BadRequest(ModelState);

            var departmentMap = _mapper.Map<Department>(departmentCreate);

            if (!_departmentRepository.CreateDepartment(empId, departmentMap))
            {
                return StatusCode(500, "Something went wrong while saving");
            }

            return Ok("Successfully Created");
        }
    }
}
