using DLL.DBContext;
using DLL.Model;
using DLL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DLL
{
    public static class DllDependency
    {
        public static void AllDependency(IServiceCollection services, IConfiguration configuration)
        {
            var mm = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IDepartmentRepository, DepartmentRepository>();
        }
    }
}