using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using WebApplication_StudentAPI_115.Models;

namespace WebApplication_StudentAPI_115.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeeDepartment> EmployeeDepartments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeDepartment>()
                .HasKey(ed => new { ed.EmployeeId, ed.DepartmentId });
            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(e => e.Employee)
                .WithMany(ed => ed.EmployeeDepartments)
                .HasForeignKey(e => e.EmployeeId);
            modelBuilder.Entity<EmployeeDepartment>()
                .HasOne(d => d.Department)
                .WithMany(ed => ed.EmployeeDepartments)
                .HasForeignKey(d => d.DepartmentId);
            modelBuilder.Entity<Blog>()
            .HasMany(e => e.Posts)
            .WithOne(e => e.Blog)
            .HasForeignKey(e => e.BlogId)
            .IsRequired();
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}
