using Boilerplate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Boilerplate.Installer
{
    public class MongoDbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IMongoClient, MongoClient>(_ => 
                new MongoClient(configuration.GetConnectionString("MongoDb")));
            
            services.AddScoped<ITestMongoTableService, TestMongoTableService>();
        }
    }
}