using Microsoft.EntityFrameworkCore;
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
            optionsBuilder.UseMySql("server=localhost;user=root;password=;database=openrp", new MariaDbServerVersion("10.4.21"));
        }
    }
}
