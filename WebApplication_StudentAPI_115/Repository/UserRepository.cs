using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication_StudentAPI_115.Data;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppSetting _appSetting;
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context, IOptions<AppSetting> appSetting)
        {
            _context = context;
            _appSetting = appSetting.Value;
        }

        public bool IsUniqueUser(string UserName)
        {
            var userInDb = _context.Users.FirstOrDefault(x => x.UserName == UserName);
            if (userInDb == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User Register(string UserName, string Password, string ConfirmPassword, string Role)
        {
            User user = new User()
            {
                UserName = UserName,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                Role = Role
            };
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        public User Authenticate(string UserName, string Password)
        {
            var userInDb = _context.Users.FirstOrDefault(x => x.UserName == UserName && x.Password == Password);
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
