using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Options;
using System.Data;
using WebApplication_StudentAPI_115.Data;
using WebApplication_StudentAPI_115.Models;
using WebApplication_StudentAPI_115.Repository.IRepository;

namespace WebApplication_StudentAPI_115.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private readonly AppSetting _appSetting;
        public UnitOfWork(ApplicationDbContext context, IOptions<AppSetting> appSetting)
        {
            _context = context;
            _appSetting = appSetting.Value;
            Student = new StudentRepository(context);
            Employee = new EmployeeRepository(context);
            User = new UserRepository(context, appSetting);
            Subject = new SubjectRepository(context);
            Department = new DepartmentRepository(context);
            Company = new CompanyRepository(context);
            Product = new ProductRepository(context);
        }

        public IStudentRepository Student { get; private set; }

        public IEmployeeRepository Employee { get; private set; }
        public IUserRepository User { get; private set; }

        public ISubjectRepository Subject { get; private set; }

        public IDepartmentRepository Department { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IProductRepository Product { get; private set; }

        public IReviewRepository Review { get; private set; }

        public IReviewerRepository Reviewer { get; private set; }

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
