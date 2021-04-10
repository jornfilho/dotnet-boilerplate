using Boilerplate.Data;
using Boilerplate.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Boilerplate.Installer
{
    public class MongoDbInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var settings = new MongoDbSettings();
            configuration.GetSection(nameof(MongoDbSettings)).Bind(settings);
            
            services.AddSingleton<IMongoDbSettings>(_ => settings);

            services.AddSingleton<IMongoClient, MongoClient>(_ => new MongoClient(settings.ConnectionStrings));
            
            services.AddScoped<ITestMongoTableService, TestMongoTableService>();
        }
    }
}