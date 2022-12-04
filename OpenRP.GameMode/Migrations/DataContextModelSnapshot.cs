﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OpenRP.GameMode.Data;

namespace OpenRP.GameMode.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Account", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<ushort>("Experience")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint unsigned")
                        .HasDefaultValue((ushort)0);

                    b.Property<byte>("Level")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint unsigned")
                        .HasDefaultValue((byte)1);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("char(60)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(24)");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Character", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("Accent")
                        .HasColumnType("varchar(30)");

                    b.Property<ulong?>("AccountId")
                        .HasColumnType("bigint unsigned");

                    b.Property<byte?>("CountryOfBirthId")
                        .HasColumnType("tinyint unsigned");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<ulong?>("InventoryId")
                        .HasColumnType("bigint unsigned");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("varchar(35)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("varchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("CountryOfBirthId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Inventory", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint unsigned");

                    b.Property<int?>("MaxWeight")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Inventories");

                    b.HasData(
                        new
                        {
                            Id = 1ul,
                            Name = "World Inventory"
                        });
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Nationality", b =>
                {
                    b.Property<byte>("Id")
                        .HasColumnType("tinyint unsigned");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Nationalities");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            Name = "Native of San Andreas"
                        },
                        new
                        {
                            Id = (byte)2,
                            Name = "Russian"
                        },
                        new
                        {
                            Id = (byte)3,
                            Name = "Afghan"
                        },
                        new
                        {
                            Id = (byte)4,
                            Name = "Albanian"
                        },
                        new
                        {
                            Id = (byte)5,
                            Name = "Algerian"
                        },
                        new
                        {
                            Id = (byte)6,
                            Name = "Argentinian"
                        },
                        new
                        {
                            Id = (byte)7,
                            Name = "Australian"
                        },
                        new
                        {
                            Id = (byte)8,
                            Name = "Austrian"
                        },
                        new
                        {
                            Id = (byte)9,
                            Name = "Bangladeshi"
                        },
                        new
                        {
                            Id = (byte)10,
                            Name = "Belgian"
                        },
                        new
                        {
                            Id = (byte)11,
                            Name = "Bolivian"
                        },
                        new
                        {
                            Id = (byte)12,
                            Name = "Batswanan"
                        },
                        new
                        {
                            Id = (byte)13,
                            Name = "Brazilian"
                        },
                        new
                        {
                            Id = (byte)14,
                            Name = "Bulgarian"
                        },
                        new
                        {
                            Id = (byte)15,
                            Name = "Cambodian"
                        },
                        new
                        {
                            Id = (byte)16,
                            Name = "Cameroonian"
                        },
                        new
                        {
                            Id = (byte)17,
                            Name = "Canadian"
                        },
                        new
                        {
                            Id = (byte)18,
                            Name = "Chilean"
                        },
                        new
                        {
                            Id = (byte)19,
                            Name = "Chinese"
                        },
                        new
                        {
                            Id = (byte)20,
                            Name = "Colombian"
                        },
                        new
                        {
                            Id = (byte)21,
                            Name = "Costa Rican"
                        },
                        new
                        {
                            Id = (byte)22,
                            Name = "Croatian"
                        },
                        new
                        {
                            Id = (byte)23,
                            Name = "Cuban"
                        },
                        new
                        {
                            Id = (byte)24,
                            Name = "Czech"
                        },
                        new
                        {
                            Id = (byte)25,
                            Name = "Danish"
                        },
                        new
                        {
                            Id = (byte)26,
                            Name = "Dominican"
                        },
                        new
                        {
                            Id = (byte)27,
                            Name = "Ecuadorian"
                        },
                        new
                        {
                            Id = (byte)28,
                            Name = "Egyptian"
                        },
                        new
                        {
                            Id = (byte)29,
                            Name = "Salvadorian"
                        },
                        new
                        {
                            Id = (byte)30,
                            Name = "English"
                        },
                        new
                        {
                            Id = (byte)31,
                            Name = "Estonian"
                        },
                        new
                        {
                            Id = (byte)32,
                            Name = "Ethiopian"
                        },
                        new
                        {
                            Id = (byte)33,
                            Name = "Fijian"
                        },
                        new
                        {
                            Id = (byte)34,
                            Name = "Finnish"
                        },
                        new
                        {
                            Id = (byte)35,
                            Name = "French"
                        },
                        new
                        {
                            Id = (byte)36,
                            Name = "German"
                        },
                        new
                        {
                            Id = (byte)37,
                            Name = "Ghanaian"
                        },
                        new
                        {
                            Id = (byte)38,
                            Name = "Greek"
                        },
                        new
                        {
                            Id = (byte)39,
                            Name = "Guatemalan"
                        },
                        new
                        {
                            Id = (byte)40,
                            Name = "Haitian"
                        },
                        new
                        {
                            Id = (byte)41,
                            Name = "Honduran"
                        },
                        new
                        {
                            Id = (byte)42,
                            Name = "Hungarian"
                        },
                        new
                        {
                            Id = (byte)43,
                            Name = "Icelandic"
                        },
                        new
                        {
                            Id = (byte)44,
                            Name = "Indian"
                        },
                        new
                        {
                            Id = (byte)45,
                            Name = "Indonesian"
                        },
                        new
                        {
                            Id = (byte)46,
                            Name = "Iranian"
                        },
                        new
                        {
                            Id = (byte)47,
                            Name = "Iraqi"
                        },
                        new
                        {
                            Id = (byte)48,
                            Name = "Irish"
                        },
                        new
                        {
                            Id = (byte)49,
                            Name = "Israeli"
                        },
                        new
                        {
                            Id = (byte)50,
                            Name = "Italian"
                        },
                        new
                        {
                            Id = (byte)51,
                            Name = "Jamaican"
                        },
                        new
                        {
                            Id = (byte)52,
                            Name = "Japanese"
                        },
                        new
                        {
                            Id = (byte)53,
                            Name = "Jordanian"
                        },
                        new
                        {
                            Id = (byte)54,
                            Name = "Kenyan"
                        },
                        new
                        {
                            Id = (byte)55,
                            Name = "Kuwaiti"
                        },
                        new
                        {
                            Id = (byte)56,
                            Name = "Lao"
                        },
                        new
                        {
                            Id = (byte)57,
                            Name = "Latvian"
                        },
                        new
                        {
                            Id = (byte)58,
                            Name = "Lebanese"
                        },
                        new
                        {
                            Id = (byte)59,
                            Name = "Libyan"
                        },
                        new
                        {
                            Id = (byte)60,
                            Name = "Lithuanian"
                        },
                        new
                        {
                            Id = (byte)61,
                            Name = "Malagasy"
                        },
                        new
                        {
                            Id = (byte)62,
                            Name = "Malaysian"
                        },
                        new
                        {
                            Id = (byte)63,
                            Name = "Malian"
                        },
                        new
                        {
                            Id = (byte)64,
                            Name = "Maltese"
                        },
                        new
                        {
                            Id = (byte)65,
                            Name = "Mexican"
                        },
                        new
                        {
                            Id = (byte)66,
                            Name = "Mongolian"
                        },
                        new
                        {
                            Id = (byte)67,
                            Name = "Moroccan"
                        },
                        new
                        {
                            Id = (byte)68,
                            Name = "Mozambican"
                        },
                        new
                        {
                            Id = (byte)69,
                            Name = "Namibian"
                        },
                        new
                        {
                            Id = (byte)70,
                            Name = "Nepalese"
                        },
                        new
                        {
                            Id = (byte)71,
                            Name = "Dutch"
                        },
                        new
                        {
                            Id = (byte)72,
                            Name = "New Zealand"
                        },
                        new
                        {
                            Id = (byte)73,
                            Name = "Nicaraguan"
                        },
                        new
                        {
                            Id = (byte)74,
                            Name = "Nigerian"
                        },
                        new
                        {
                            Id = (byte)75,
                            Name = "Norwegian"
                        },
                        new
                        {
                            Id = (byte)76,
                            Name = "Pakistani"
                        },
                        new
                        {
                            Id = (byte)77,
                            Name = "Panamanian"
                        },
                        new
                        {
                            Id = (byte)78,
                            Name = "Paraguayan"
                        },
                        new
                        {
                            Id = (byte)79,
                            Name = "Peruvian"
                        },
                        new
                        {
                            Id = (byte)80,
                            Name = "Philippine"
                        },
                        new
                        {
                            Id = (byte)81,
                            Name = "Polish"
                        },
                        new
                        {
                            Id = (byte)82,
                            Name = "Portuguese"
                        },
                        new
                        {
                            Id = (byte)83,
                            Name = "Romanian "
                        },
                        new
                        {
                            Id = (byte)84,
                            Name = "Saudi"
                        },
                        new
                        {
                            Id = (byte)85,
                            Name = "Scottish"
                        },
                        new
                        {
                            Id = (byte)86,
                            Name = "Senegalese"
                        },
                        new
                        {
                            Id = (byte)87,
                            Name = "Serbian"
                        },
                        new
                        {
                            Id = (byte)88,
                            Name = "Singaporean"
                        },
                        new
                        {
                            Id = (byte)89,
                            Name = "Slovak"
                        },
                        new
                        {
                            Id = (byte)90,
                            Name = "South African"
                        },
                        new
                        {
                            Id = (byte)91,
                            Name = "Korean"
                        },
                        new
                        {
                            Id = (byte)92,
                            Name = "Spanish"
                        },
                        new
                        {
                            Id = (byte)93,
                            Name = "Sri Lankan"
                        },
                        new
                        {
                            Id = (byte)94,
                            Name = "Sudanese"
                        },
                        new
                        {
                            Id = (byte)95,
                            Name = "Swedish"
                        },
                        new
                        {
                            Id = (byte)96,
                            Name = "Swiss"
                        },
                        new
                        {
                            Id = (byte)97,
                            Name = "Syrian"
                        },
                        new
                        {
                            Id = (byte)98,
                            Name = "Taiwanese"
                        },
                        new
                        {
                            Id = (byte)99,
                            Name = "Tajikistani"
                        },
                        new
                        {
                            Id = (byte)100,
                            Name = "Thai"
                        },
                        new
                        {
                            Id = (byte)101,
                            Name = "Tongan"
                        },
                        new
                        {
                            Id = (byte)102,
                            Name = "Tunisian"
                        },
                        new
                        {
                            Id = (byte)103,
                            Name = "Turkish"
                        },
                        new
                        {
                            Id = (byte)104,
                            Name = "Ukrainian"
                        },
                        new
                        {
                            Id = (byte)105,
                            Name = "Emirati"
                        },
                        new
                        {
                            Id = (byte)106,
                            Name = "British"
                        },
                        new
                        {
                            Id = (byte)107,
                            Name = "American"
                        },
                        new
                        {
                            Id = (byte)108,
                            Name = "Uruguayan"
                        },
                        new
                        {
                            Id = (byte)109,
                            Name = "Venezuelan"
                        },
                        new
                        {
                            Id = (byte)110,
                            Name = "Vietnamese"
                        },
                        new
                        {
                            Id = (byte)111,
                            Name = "Welsh"
                        },
                        new
                        {
                            Id = (byte)112,
                            Name = "Zambian"
                        },
                        new
                        {
                            Id = (byte)113,
                            Name = "Zimbabwean"
                        },
                        new
                        {
                            Id = (byte)114,
                            Name = "Native of Caeroyna"
                        });
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Character", b =>
                {
                    b.HasOne("OpenRP.GameMode.Data.Models.Account", null)
                        .WithMany("Characters")
                        .HasForeignKey("AccountId");

                    b.HasOne("OpenRP.GameMode.Data.Models.Nationality", "CountryOfBirth")
                        .WithMany()
                        .HasForeignKey("CountryOfBirthId");

                    b.HasOne("OpenRP.GameMode.Data.Models.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.Navigation("CountryOfBirth");

                    b.Navigation("Inventory");
                });

            modelBuilder.Entity("OpenRP.GameMode.Data.Models.Account", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
