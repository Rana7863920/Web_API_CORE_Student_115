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
        }

        public IStudentRepository Student { get; private set; }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
