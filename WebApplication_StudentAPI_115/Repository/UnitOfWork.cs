using Microsoft.EntityFrameworkCore.Storage;
using System.Data;
using WebApplication_StudentAPI_115.Data;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Student = new StudentRepository(context);
            Employee = new EmployeeRepository(context);
            User = new UserRepository(context);
        }

        public IStudentRepository Student { get; private set; }

        public IEmployeeRepository Employee { get; private set; }
        public IUserRepository User { get; private set; }

        public IDbTransaction BeginTransaction()
        {
            var transaction = _context.Database.BeginTransaction();

            return transaction.GetDbTransaction();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
