using Microsoft.EntityFrameworkCore;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data.Models;

namespace OpenRP.GameMode.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Inventory> Inventories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConfigManager.Instance.Data.ConnectionString, new MariaDbServerVersion("10.4.21"));
        }
    }
}
