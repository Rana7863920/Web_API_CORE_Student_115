using Microsoft.EntityFrameworkCore.Diagnostics;
using WebApplication_StudentAPI_115.Data;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Repository
{
    public class DepartmentRepository:Repository<Department>, IDepartmentRepository
    {
        private readonly ApplicationDbContext _context;
        public DepartmentRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public bool CreateDepartment(int employeeId, Department department)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                var employeeEntity = _context.Employees.FirstOrDefault(x => x.Id == employeeId);

                var employeeDepartment = new EmployeeDepartment()
                {
                    Employee = employeeEntity,
                    Department = department
                };

                _context.Add(department);
                transaction.Commit();

                if (employeeEntity == null) throw new Exception();
                _context.Add(employeeDepartment);

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
                return false;
            }

            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
