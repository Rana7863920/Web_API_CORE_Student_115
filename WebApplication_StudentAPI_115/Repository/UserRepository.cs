using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApplication_StudentAPI_115.Data;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Models.ViewModels;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSetting _appSetting;
        public UserRepository(ApplicationDbContext context, IOptions<AppSetting> appSetting) : base(context)
        {
            _context = context;
            _appSetting = appSetting.Value;
        }

        public bool IsUniqueUser(UserVM2 user)
        {
            var userInDb = _context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Role == user.Role);
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
            var user2 = _context.Users.FirstOrDefault(x => x.UserName == userVM2.UserName);
            if (user2 == null)
            {
                User user = new User()
                {
                    UserName = userVM2.UserName,
                    Password = userVM2.Password,
                    ConfirmPassword = userVM2.ConfirmPassword,
                    Role = userVM2.Role
                };
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            else
            {
                return null;
            }
        }
        public User Authenticate(UserVM user)
        {
            var userInDb = _context.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == user.Password);
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
