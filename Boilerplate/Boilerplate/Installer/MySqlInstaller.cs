using System;
using Boilerplate.Data;
using Boilerplate.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Installer
{
    public class MySqlInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MariaDb");
            services.AddDbContext<MySqlDataContext>(options =>
                options.UseMySql(connectionString, new MariaDbServerVersion(new Version()))
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors());
            
            services.AddScoped<ITestMySqlTableService, TestMySqlTableService>();
        }
    }
}