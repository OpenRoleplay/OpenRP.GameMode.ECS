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
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConfigManager.Instance.Data.ConnectionString, new MariaDbServerVersion("10.4.21"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Default Data
            #region Inventories Default Data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = 1,
                    Name = "World Inventory",
                    MaxWeight = null,
                }
            );
            #endregion
            #endregion

            #region Default Values
            #region Accounts Default Values
            modelBuilder.Entity<Account>()
            .Property(b => b.Level)
            .HasDefaultValue(1);

            modelBuilder.Entity<Account>()
            .Property(b => b.Experience)
            .HasDefaultValue(0);
            #endregion

            #region Characters Default Values
            modelBuilder.Entity<Character>()
            .Property(b => b.Skin)
            .HasDefaultValue(26);
            #endregion
            #endregion
        }
    }
}
