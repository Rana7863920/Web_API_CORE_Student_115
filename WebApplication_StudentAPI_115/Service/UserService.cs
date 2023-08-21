using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Models.ViewModels;
using WebApplication_StudentAPI_115.Repository.IRepository;
using WebApplication_StudentAPI_115.Service.IService;

namespace WebApplication_StudentAPI_115.Service
{
    public class UserService:IUserService
    {
        private readonly AppSetting _appSetting;
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork, IOptions<AppSetting> appSetting)
        {
            _unitOfWork = unitOfWork;
            _appSetting = appSetting.Value;
        }

        public bool IsUniqueUser(string UserName)
        {
            var userInDb = _unitOfWork.User.FirstorDefault(x => x.UserName == UserName);
            if (userInDb == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Register(UserVM2 userVM2)
        {
            User user = new User()
            {
                UserName = userVM2.UserName,
                Password = userVM2.Password,
                ConfirmPassword = userVM2.ConfirmPassword,
                Role = userVM2.Role
            };
            _unitOfWork.User.Add(user);
            _unitOfWork.Save();
            return user;
        }
        public User Authenticate(UserVM user)
        {
            var userInDb = _unitOfWork.User.FirstorDefault(x => x.UserName == user.UserName && x.Password == user.Password);
            if (userInDb == null) return null;
            else
            {
                // JWT Authentication
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSetting.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, userInDb.Id.ToString()),
                        new Claim(ClaimTypes.Role, userInDb.Role)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                userInDb.Token = tokenHandler.WriteToken(token);
                userInDb.Password = "";
                userInDb.ConfirmPassword = "";
                return userInDb;
            }
        }
    }
}
