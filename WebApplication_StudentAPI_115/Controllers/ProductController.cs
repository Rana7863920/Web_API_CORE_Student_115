using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _unitOfWork.Product.GetAll();
            return Ok(products);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(product);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateProduct([FromBody]Product product)
        {
            if (product == null) return BadRequest();
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Update(product);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _unitOfWork.Product.Find(id);
            if (product == null) return NotFound();
            _unitOfWork.Product.Delete(product);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
