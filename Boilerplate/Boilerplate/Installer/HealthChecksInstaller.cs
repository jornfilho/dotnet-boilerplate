using Boilerplate.Data;
using Boilerplate.HealthChecks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Boilerplate.Installer
{
    public class HealthChecksInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddHealthChecks()
                .AddDbContextCheck<MsSqlDataContext>("MsSql")
                .AddDbContextCheck<MySqlDataContext>("MySql")
                .AddCheck<RedisHealthCheck>("Redis")
                .AddCheck<MongoDbHealthCheck>("MongoDb");
        }
    }
}