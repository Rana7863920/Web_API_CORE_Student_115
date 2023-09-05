using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_StudentAPI_115.DTOs;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CompanyController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetCompanies()
        {
            var companies = _mapper.Map<List<CompanyDTO>>(_unitOfWork.Company.GetAll());
            return Ok(companies);
        }
        [HttpPost]
        public IActionResult CreateCompany([FromBody] CompanyDTO company)
        {
            if (company == null) return BadRequest();
            if (ModelState.IsValid)
            {
                var companyMap = _mapper.Map<Company>(company);
                _unitOfWork.Company.Add(companyMap);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCompany([FromBody] CompanyDTO company)
        {
            if(company == null) return BadRequest();
            if (ModelState.IsValid)
            {
                var companyMap = _mapper.Map<Company>(company);
                _unitOfWork.Company.Update(companyMap);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCompany(int id)
        {
            var company = _unitOfWork.Company.Find(id);
            if(company == null) return BadRequest();
            _unitOfWork.Company.Delete(company);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
