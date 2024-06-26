﻿using Microsoft.EntityFrameworkCore;
using FincoraConsoleAppDemo.Models;

namespace FincoraConsoleAppDemo.Context
{
    public class MyAppContext : DbContext
    {
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<InsuranceCompany> InsuranceCompanies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /*var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var dbPath = Path.Combine(basePath, "myapp.db");

            optionsBuilder.UseSqlite($"Filename={dbPath}", option =>
            {
                option.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
            });
            base.OnConfiguring(optionsBuilder);*/

            string dbPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "myapp.db");
            optionsBuilder.UseLazyLoadingProxies().UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractType>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);
            });

            modelBuilder.Entity<InsuranceCompany>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Name).IsUnique();
                entity.HasIndex(e => e.PhoneNumber).IsUnique();
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.PhoneNumber).IsUnique(); 
            });

            modelBuilder.Entity<Vehicle>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.EvidenceNumber).IsUnique();
            });

            modelBuilder.Entity<Contract>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.VehicleId).IsRequired(false);
                entity.Property(b => b.Status)
                      .HasDefaultValue("Active");
                entity.Property(b => b.SignDate)
                      .HasDefaultValue(DateOnly.FromDateTime(DateTime.Now));
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
