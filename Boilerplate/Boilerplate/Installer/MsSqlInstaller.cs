using Boilerplate.Data;
using Boilerplate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace Boilerplate.Installer
{
    public class MsSqlInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MsSqlDataContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("MsSql")));
            
            services.AddScoped<ITestMsSqlTableService, TestMsSqlTableService>();
        }
    }
}