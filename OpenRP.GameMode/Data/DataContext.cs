using Microsoft.EntityFrameworkCore;
using OpenRP.GameMode.Configuration;
using OpenRP.GameMode.Data.Models;
using System;

namespace OpenRP.GameMode.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<DroppedInventoryItem> DroppedInventoryItems { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<ItemType> ItemTypes { get; set; }
        public DbSet<Actor> Actors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(ConfigManager.Instance.Data.ConnectionString, new MariaDbServerVersion("10.4.21")).LogTo(Console.WriteLine);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Default Data
            #region Inventories Default Data
            modelBuilder.Entity<Inventory>().HasData(
                new Inventory
                {
                    Id = 1
                    , Name = "World Inventory"
                    , MaxWeight = null,
                }
            );
            #endregion
            #region ItemTypes Default Data
            modelBuilder.Entity<ItemType>().HasData(
                new ItemType
                {
                    Id = 1
                    , Name = "Skin"
                },
                new ItemType
                {
                    Id = 2
                    , Name = "Wallet"
                }
            );
            #endregion
            #region Items Default Data
            modelBuilder.Entity<Item>().HasData(
                new Item
                {
                    Id = 1
                    , Name = "Kir Jong Uniform"
                    , Description = "Introducing the Kir Jong Uniform - because even mad scientists need to look sharp while plotting world domination! This ensemble screams 'I'm up to no good,' with its sleek black suit, buttoned-up jacket, and a hint of red that says, 'I'm the boss, but I have a sense of style.' Perfect for leading Russian separatists, running secret research facilities, and, of course, experimenting on humans. Complete the look and let the world know you mean business... even if it's highly unethical!"
                    , UseTypeId = 1
                    , Weight = 500
                    , CanDrop = false
                    , CanDestroy = true
                    , KeepOnDeath = true
                    , UseValue = "[SKIN=295]"
                },
                new Item
                {
                    Id = 2
                    , Name = "Wallet"
                    , Description = "Because your virtual pockets just couldn't handle the weight of all that pixelated cash. Now you can carry your hard-earned pixels in style and show the virtual world that you're not just rich, you're wallet-rich!"
                    , UseTypeId = 2
                    , Weight = 25
                    , CanDrop = true
                    , CanDestroy = true
                    , KeepOnDeath = true
                }
            );
            #endregion
            #endregion
        }
    }
}
