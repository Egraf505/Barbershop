using Barbershop.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace Barbershop.Persistence
{
    public class BarbershopContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public Microsoft.EntityFrameworkCore.DbSet<Record> Records { get; set; }
        public Microsoft.EntityFrameworkCore.DbSet<Service> Services { get; set; }

        public BarbershopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=barbershopdata.db");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().HasKey(x => x.Id);
            modelBuilder.Entity<Service>().HasIndex(x => x.Id).IsUnique();

            modelBuilder.Entity<Record>().HasKey(x => x.Id);
            modelBuilder.Entity<Record>().HasIndex(x => x.Id).IsUnique();

            base.OnModelCreating(modelBuilder);
        }
    }
}
