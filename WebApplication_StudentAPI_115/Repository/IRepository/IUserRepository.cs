using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Models.ViewModels;

namespace WebApplication_StudentAPI_115.Repository.IRepository
{
    public interface IUserRepository:IRepository<User>
    {
        bool IsUniqueUser(UserVM2 user);
        User Authenticate(UserVM user);
        User Register(UserVM2 userVM2);
    }
}
