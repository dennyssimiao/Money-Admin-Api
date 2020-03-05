using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MoneyAdmin.Domain;

namespace MoneyAdmin.Infra.Data
{
    public class MoneyAdminContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MoneyAdminContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlServer(_configuration.GetConnectionString("MoneyAdminMssql"));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Account> Accounts { get; set; }
    }
}
