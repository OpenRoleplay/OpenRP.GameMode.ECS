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
        public DbSet<Nationality> Nationalities { get; set; }
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

            #region Nationailities Default Data
            modelBuilder.Entity<Nationality>().HasData(
                new Nationality
                {
                    Id = 1,
                    Name = "Native of San Andreas",
                },
                new Nationality
                {
                    Id = 2,
                    Name = "Russian",
                },
                new Nationality
                {
                    Id = 3,
                    Name = "Afghan",
                },
                new Nationality
                {
                    Id = 4,
                    Name = "Albanian",
                },
                new Nationality
                {
                    Id = 5,
                    Name = "Algerian",
                },
                new Nationality
                {
                    Id = 6,
                    Name = "Argentinian",
                },
                new Nationality
                {
                    Id = 7,
                    Name = "Australian",
                },
                new Nationality
                {
                    Id = 8,
                    Name = "Austrian",
                },
                new Nationality
                {
                    Id = 9,
                    Name = "Bangladeshi",
                },
                new Nationality
                {
                    Id = 10,
                    Name = "Belgian",
                },
                new Nationality
                {
                    Id = 11,
                    Name = "Bolivian",
                },
                new Nationality
                {
                    Id = 12,
                    Name = "Batswanan",
                },
                new Nationality
                {
                    Id = 13,
                    Name = "Brazilian",
                },
                new Nationality
                {
                    Id = 14,
                    Name = "Bulgarian",
                },
                new Nationality
                {
                    Id = 15,
                    Name = "Cambodian",
                },
                new Nationality
                {
                    Id = 16,
                    Name = "Cameroonian",
                },
                new Nationality
                {
                    Id = 17,
                    Name = "Canadian",
                },
                new Nationality
                {
                    Id = 18,
                    Name = "Chilean",
                },
                new Nationality
                {
                    Id = 19,
                    Name = "Chinese",
                },
                new Nationality
                {
                    Id = 20,
                    Name = "Colombian",
                },
                new Nationality
                {
                    Id = 21,
                    Name = "Costa Rican",
                },
                new Nationality
                {
                    Id = 22,
                    Name = "Croatian",
                },
                new Nationality
                {
                    Id = 23,
                    Name = "Cuban",
                },
                new Nationality
                {
                    Id = 24,
                    Name = "Czech",
                },
                new Nationality
                {
                    Id = 25,
                    Name = "Danish",
                },
                new Nationality
                {
                    Id = 26,
                    Name = "Dominican",
                },
                new Nationality
                {
                    Id = 27,
                    Name = "Ecuadorian",
                },
                new Nationality
                {
                    Id = 28,
                    Name = "Egyptian",
                },
                new Nationality
                {
                    Id = 29,
                    Name = "Salvadorian",
                },
                new Nationality
                {
                    Id = 30,
                    Name = "English",
                },
                new Nationality
                {
                    Id = 31,
                    Name = "Estonian",
                },
                new Nationality
                {
                    Id = 32,
                    Name = "Ethiopian",
                },
                new Nationality
                {
                    Id = 33,
                    Name = "Fijian",
                },
                new Nationality
                {
                    Id = 34,
                    Name = "Finnish",
                },
                new Nationality
                {
                    Id = 35,
                    Name = "French",
                },
                new Nationality
                {
                    Id = 36,
                    Name = "German",
                },
                new Nationality
                {
                    Id = 37,
                    Name = "Ghanaian",
                },
                new Nationality
                {
                    Id = 38,
                    Name = "Greek",
                },
                new Nationality
                {
                    Id = 39,
                    Name = "Guatemalan",
                },
                new Nationality
                {
                    Id = 40,
                    Name = "Haitian",
                },
                new Nationality
                {
                    Id = 41,
                    Name = "Honduran",
                },
                new Nationality
                {
                    Id = 42,
                    Name = "Hungarian",
                },
                new Nationality
                {
                    Id = 43,
                    Name = "Icelandic",
                },
                new Nationality
                {
                    Id = 44,
                    Name = "Indian",
                },
                new Nationality
                {
                    Id = 45,
                    Name = "Indonesian",
                },
                new Nationality
                {
                    Id = 46,
                    Name = "Iranian",
                },
                new Nationality
                {
                    Id = 47,
                    Name = "Iraqi",
                },
                new Nationality
                {
                    Id = 48,
                    Name = "Irish",
                },
                new Nationality
                {
                    Id = 49,
                    Name = "Israeli",
                },
                new Nationality
                {
                    Id = 50,
                    Name = "Italian",
                },
                new Nationality
                {
                    Id = 51,
                    Name = "Jamaican",
                },
                new Nationality
                {
                    Id = 52,
                    Name = "Japanese",
                },
                new Nationality
                {
                    Id = 53,
                    Name = "Jordanian",
                },
                new Nationality
                {
                    Id = 54,
                    Name = "Kenyan",
                },
                new Nationality
                {
                    Id = 55,
                    Name = "Kuwaiti",
                },
                new Nationality
                {
                    Id = 56,
                    Name = "Lao",
                },
                new Nationality
                {
                    Id = 57,
                    Name = "Latvian",
                },
                new Nationality
                {
                    Id = 58,
                    Name = "Lebanese",
                },
                new Nationality
                {
                    Id = 59,
                    Name = "Libyan",
                },
                new Nationality
                {
                    Id = 60,
                    Name = "Lithuanian",
                },
                new Nationality
                {
                    Id = 61,
                    Name = "Malagasy",
                },
                new Nationality
                {
                    Id = 62,
                    Name = "Malaysian",
                },
                new Nationality
                {
                    Id = 63,
                    Name = "Malian",
                },
                new Nationality
                {
                    Id = 64,
                    Name = "Maltese",
                },
                new Nationality
                {
                    Id = 65,
                    Name = "Mexican",
                },
                new Nationality
                {
                    Id = 66,
                    Name = "Mongolian",
                },
                new Nationality
                {
                    Id = 67,
                    Name = "Moroccan",
                },
                new Nationality
                {
                    Id = 68,
                    Name = "Mozambican",
                },
                new Nationality
                {
                    Id = 69,
                    Name = "Namibian",
                },
                new Nationality
                {
                    Id = 70,
                    Name = "Nepalese",
                },
                new Nationality
                {
                    Id = 71,
                    Name = "Dutch",
                },
                new Nationality
                {
                    Id = 72,
                    Name = "New Zealand",
                },
                new Nationality
                {
                    Id = 73,
                    Name = "Nicaraguan",
                },
                new Nationality
                {
                    Id = 74,
                    Name = "Nigerian",
                },
                new Nationality
                {
                    Id = 75,
                    Name = "Norwegian",
                },
                new Nationality
                {
                    Id = 76,
                    Name = "Pakistani",
                },
                new Nationality
                {
                    Id = 77,
                    Name = "Panamanian",
                },
                new Nationality
                {
                    Id = 78,
                    Name = "Paraguayan",
                },
                new Nationality
                {
                    Id = 79,
                    Name = "Peruvian",
                },
                new Nationality
                {
                    Id = 80,
                    Name = "Philippine",
                },
                new Nationality
                {
                    Id = 81,
                    Name = "Polish",
                },
                new Nationality
                {
                    Id = 82,
                    Name = "Portuguese",
                },
                new Nationality
                {
                    Id = 83,
                    Name = "Romanian ",
                },
                new Nationality
                {
                    Id = 84,
                    Name = "Saudi",
                },
                new Nationality
                {
                    Id = 85,
                    Name = "Scottish",
                },
                new Nationality
                {
                    Id = 86,
                    Name = "Senegalese",
                },
                new Nationality
                {
                    Id = 87,
                    Name = "Serbian",
                },
                new Nationality
                {
                    Id = 88,
                    Name = "Singaporean",
                },
                new Nationality
                {
                    Id = 89,
                    Name = "Slovak",
                },
                new Nationality
                {
                    Id = 90,
                    Name = "South African",
                },
                new Nationality
                {
                    Id = 91,
                    Name = "Korean",
                },
                new Nationality
                {
                    Id = 92,
                    Name = "Spanish",
                },
                new Nationality
                {
                    Id = 93,
                    Name = "Sri Lankan",
                },
                new Nationality
                {
                    Id = 94,
                    Name = "Sudanese",
                },
                new Nationality
                {
                    Id = 95,
                    Name = "Swedish",
                },
                new Nationality
                {
                    Id = 96,
                    Name = "Swiss",
                },
                new Nationality
                {
                    Id = 97,
                    Name = "Syrian",
                },
                new Nationality
                {
                    Id = 98,
                    Name = "Taiwanese",
                },
                new Nationality
                {
                    Id = 99,
                    Name = "Tajikistani",
                },
                new Nationality
                {
                    Id = 100,
                    Name = "Thai",
                },
                new Nationality
                {
                    Id = 101,
                    Name = "Tongan",
                },
                new Nationality
                {
                    Id = 102,
                    Name = "Tunisian",
                },
                new Nationality
                {
                    Id = 103,
                    Name = "Turkish",
                },
                new Nationality
                {
                    Id = 104,
                    Name = "Ukrainian",
                },
                new Nationality
                {
                    Id = 105,
                    Name = "Emirati",
                },
                new Nationality
                {
                    Id = 106,
                    Name = "British",
                },
                new Nationality
                {
                    Id = 107,
                    Name = "American",
                },
                new Nationality
                {
                    Id = 108,
                    Name = "Uruguayan",
                },
                new Nationality
                {
                    Id = 109,
                    Name = "Venezuelan",
                },
                new Nationality
                {
                    Id = 110,
                    Name = "Vietnamese",
                },
                new Nationality
                {
                    Id = 111,
                    Name = "Welsh",
                },
                new Nationality
                {
                    Id = 112,
                    Name = "Zambian",
                },
                new Nationality
                {
                    Id = 113,
                    Name = "Zimbabwean",
                },
                new Nationality
                {
                    Id = 114,
                    Name = "Native of Caeroyna",
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
            #endregion
        }
    }
}
