using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Models.ViewModels;

namespace WebApplication_StudentAPI_115.Service.IService
{
    public interface IUserService
    {
        bool IsUniqueUser(string UserName);
        User Authenticate(UserVM user);
        User Register(UserVM2 userVM2);
    }
}
