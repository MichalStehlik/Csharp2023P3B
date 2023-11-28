using C02EFC.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C02EFC.Data
{
    internal class ApplicationDbContext : DbContext
    {
        private string _connectionString;

        public ApplicationDbContext() : base()
        {
            _connectionString = @"Data Source=myGames.sqlite";
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Company> Companies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(_connectionString);
            optionsBuilder.LogTo(Console.WriteLine, new[]
            {
                RelationalEventId.CommandExecuted
            });
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Company>().HasData(new Company { CompanyId = 1, Name = "CD Project RED"});
            modelBuilder.Entity<Company>().HasData(new Company { CompanyId = 2, Name = "Bethesda" });
            modelBuilder.Entity<Company>().HasData(new Company { CompanyId = 3, Name = "Obsidian" });
            modelBuilder.Entity<Game>().HasData(new Game { GameId = 1, Name = "Cyberpunk 2077", DeveloperId = 1 });
            modelBuilder.Entity<Game>().HasData(new Game { GameId = 2, Name = "Skyrim", DeveloperId = 2 });
            modelBuilder.Entity<Game>().HasData(new Game { GameId = 3, Name = "Fallout 4", DeveloperId = 2 });
            modelBuilder.Entity<Game>().HasData(new Game { GameId = 4, Name = "Starfield", DeveloperId = 2 });
            modelBuilder.Entity<Game>().HasData(new Game { GameId = 5, Name = "Oblivion", DeveloperId = 2 });
            modelBuilder.Entity<Game>().HasData(new Game { GameId = 6, Name = "Outer Worlds", DeveloperId = 3 });

        }
    }
    /*
     * Migrace:
     * NuGet\Package Manager Console
     * Add-Migration Init
     * Update-Database
     */
}
