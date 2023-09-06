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
    public class BlogController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BlogController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetBlogs()
        {
            var blogs = _unitOfWork.Blog.GetAll();
            foreach (var blog in blogs)
            {
                var posts = _mapper.Map<List<PostDTO>>(_unitOfWork.Post.GetAll(x => x.BlogId == blog.Id));
            }
            return Ok(blogs);
        }
        [HttpPost]
        public IActionResult CreateBlog([FromBody] BlogDTO blogDTO)
        {
            if (blogDTO == null) return BadRequest();
            if (ModelState.IsValid)
            {
                var blogMap = _mapper.Map<Blog>(blogDTO);
                _unitOfWork.Blog.Add(blogMap);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateBlog([FromBody] BlogDTO blogDTO)
        {
            if(blogDTO == null) return BadRequest();
            if (ModelState.IsValid)
            {
                var blogMap = _mapper.Map<Blog>(blogDTO);
                _unitOfWork.Blog.Update(blogMap);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteBlog(int id)
        {
            var blog = _unitOfWork.Blog.Find(id);
            if (blog == null) return NotFound();
            _unitOfWork.Blog.Delete(blog);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
