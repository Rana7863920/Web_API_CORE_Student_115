using Microsoft.EntityFrameworkCore;
using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
