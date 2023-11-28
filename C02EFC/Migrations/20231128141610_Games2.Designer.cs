﻿// <auto-generated />
using C02EFC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace C02EFC.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231128141610_Games2")]
    partial class Games2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.14");

            modelBuilder.Entity("C02EFC.Models.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            CompanyId = 1,
                            Name = "CD Project RED"
                        },
                        new
                        {
                            CompanyId = 2,
                            Name = "Bethesda"
                        },
                        new
                        {
                            CompanyId = 3,
                            Name = "Obsidian"
                        });
                });

            modelBuilder.Entity("C02EFC.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GameId");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            GameId = 1,
                            DeveloperId = 1,
                            Name = "Cyberpunk 2077"
                        },
                        new
                        {
                            GameId = 2,
                            DeveloperId = 2,
                            Name = "Skyrim"
                        },
                        new
                        {
                            GameId = 3,
                            DeveloperId = 2,
                            Name = "Fallout 4"
                        },
                        new
                        {
                            GameId = 4,
                            DeveloperId = 2,
                            Name = "Starfield"
                        },
                        new
                        {
                            GameId = 5,
                            DeveloperId = 2,
                            Name = "Oblivion"
                        },
                        new
                        {
                            GameId = 6,
                            DeveloperId = 3,
                            Name = "Outer Worlds"
                        });
                });

            modelBuilder.Entity("C02EFC.Models.Game", b =>
                {
                    b.HasOne("C02EFC.Models.Company", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("C02EFC.Models.Company", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
