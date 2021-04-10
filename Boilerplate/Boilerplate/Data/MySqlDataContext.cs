using Boilerplate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Boilerplate.Data
{
    public class MySqlDataContext : DbContext
    {
        public MySqlDataContext(DbContextOptions<MySqlDataContext> options, IConfiguration configuration)
            : base(options)
        {
        }
        
        public DbSet<MySqlTable> MySqlTable { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}