using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Repository.IRepository
{
    public interface IUserRepository
    {
        bool IsUniqueUser(string UserName);
        User Authenticate(string UserName, string Password);
        User Register(string UserName, string Password, string ConfirmPassword, string Role);
    }
}
