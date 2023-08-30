﻿using Microsoft.AspNetCore.Diagnostics;
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
        private readonly ILogger<User> _logger;
        public UserController(IUserService userService, IUnitOfWork unitOfWork, ILogger<User> logger)
        {
            _userService = userService;
            _unitOfWork = unitOfWork;
            _logger = logger;
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
                        var userInfo = _userService.Register(user);
                        if (userInfo == null) return BadRequest("User in use!!");
                        _logger.LogInformation("User registered");
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
            if (user == null) throw new Exception("wrong username/password");
            _logger.LogInformation("User got login");
            return Ok(user);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error-development")]
        public IActionResult HandleErrorDevelopment(
        [FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message);
        }
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult HandleError() =>
            Problem();
    }
}
