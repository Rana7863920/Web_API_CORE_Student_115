using Microsoft.EntityFrameworkCore;
using WebApplication_StudentAPI_115.Repository.IRepository;
using WebApplication_StudentAPI_115.Repository;
using WebApplication_StudentAPI_115.Data;

namespace WebApplication_StudentAPI_115
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("conStr"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            

            return services;
        }
    }
}
