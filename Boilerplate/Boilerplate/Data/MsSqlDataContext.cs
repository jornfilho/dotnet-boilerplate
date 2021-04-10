using Boilerplate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Boilerplate.Data
{
    public class MsSqlDataContext : DbContext
    {
        public MsSqlDataContext(DbContextOptions<MsSqlDataContext> options, IConfiguration configuration)
            : base(options)
        {
        }
        
        public DbSet<MsSqlTable> MsSqlTable { get; set; }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}