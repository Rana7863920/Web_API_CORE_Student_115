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
        private readonly IUnitOfWork _unitOfWork;
        public UserController(IUserService userService, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
        }
        [HttpPost("register")]
        public IActionResult Register([FromBody]List<UserVM2> users)
        {
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                if (ModelState.IsValid)
                {
                    foreach (var user in users)
                    {
                        var isUniqueUser = _userService.IsUniqueUser(user);
                        if (!isUniqueUser)
                            return BadRequest("User in use!!");
                        var userInfo = _userService.Register(user);
                        if (userInfo == null) return BadRequest();
                    }
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return StatusCode(404, ex.Message);
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
