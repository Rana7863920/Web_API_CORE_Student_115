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
    public class PostController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetPosts()
        {
            var posts = _mapper.Map<List<PostDTO>>(_unitOfWork.Post.GetAll());
            return Ok(posts);
        }
        [HttpPost]
        public IActionResult CreatePost([FromBody] PostDTO postDTO)
        {
            if (postDTO == null) return BadRequest();
            if (ModelState.IsValid)
            {
                var postMap = _mapper.Map<Post>(postDTO);
                _unitOfWork.Post.Add(postMap);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdatePost([FromBody] PostDTO postDTO)
        {
            if(postDTO == null) return BadRequest();
            if(ModelState.IsValid)
            {
                var postMap = _mapper.Map<Post>(postDTO);
                _unitOfWork.Post.Update(postMap);
                _unitOfWork.Save();
            }
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeletePost(int id)
        {
            var post = _unitOfWork.Post.Find(id);
            if (post == null) return NotFound();
            _unitOfWork.Post.Delete(post);
            _unitOfWork.Save();
            return Ok();
        }
    }
}
