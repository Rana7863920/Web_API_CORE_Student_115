using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Repository.IRepository
{
    public interface IEmployeeRepository:IRepository<Employee>
    {
        bool CreateEmployee(int departmentId, Employee employee);
        bool UpdateEmployee(int oldDepartmentId, int newDepartmentId, Employee employee);
        bool Save();
    }
}
