using Microsoft.Extensions.Options;
using WebApplication_StudentAPI_115.Data;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Repository
{
    public class EmployeeRepository:Repository<Employee>, IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;
        public EmployeeRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool CreateEmployee(int departmentId, Employee employee)
        {
            var departmentEntity = _context.Departments.FirstOrDefault(x => x.Id == departmentId);

            var employeeDepartment = new EmployeeDepartment()
            {
                Department = departmentEntity,
                Employee = employee
            };

            _context.Add(employee);
            _context.Add(employeeDepartment);

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateEmployee(int newDepartmentId, int oldDepartmentId, Employee employee)
        {
            var employeeDepartmentFromDb = _context.EmployeeDepartments.FirstOrDefault(x => x.EmployeeId == employee.Id &&
                                                                                             x.DepartmentId == oldDepartmentId);
            if (newDepartmentId == oldDepartmentId)
                _context.Update(employeeDepartmentFromDb);
            else
            {
                _context.Remove(employeeDepartmentFromDb);
                var department = _context.Departments.FirstOrDefault(x => x.Id == newDepartmentId);
                var employeeDepartment = new EmployeeDepartment()
                {
                    Department = department,
                    Employee = employee
                };
                _context.Add(employeeDepartment);
            }
            _context.Update(employee);
            return Save();
        }
    }
}
