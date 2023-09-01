using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Repository.IRepository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        bool CreateDepartment(int employeeId, Department department);
    }
}
