using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Models.ViewModels;
using WebApplication_StudentAPI_115.Repository.IRepository;
using WebApplication_StudentAPI_115.Service.IService;

namespace WebApplication_StudentAPI_115.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody]UserVM2 user)
        {
            if (ModelState.IsValid)
            {
                var isUniqueUser = _userService.IsUniqueUser(user.UserName);
                if (!isUniqueUser)
                    return BadRequest("User in use!!");
                var userInfo = _userService.Register(user);
                if (userInfo == null) return BadRequest();
            }
            return Ok();
        }
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]UserVM userVM)
        {
            var user = _userService.Authenticate(userVM);
            if (user == null) return BadRequest("Wrong Username/Password");
            return Ok(user);
        }
    }
}
