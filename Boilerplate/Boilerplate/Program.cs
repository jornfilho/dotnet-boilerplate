using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boilerplate.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Boilerplate
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            
            using (var serviceScope = host.Services.CreateScope())
            {
                var dbMsSqlContext = serviceScope.ServiceProvider.GetRequiredService<MsSqlDataContext>();
                var dbMySqlContext = serviceScope.ServiceProvider.GetRequiredService<MySqlDataContext>();

                await dbMsSqlContext.Database.MigrateAsync();
                await dbMySqlContext.Database.MigrateAsync();
            }
            
            await host.RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}