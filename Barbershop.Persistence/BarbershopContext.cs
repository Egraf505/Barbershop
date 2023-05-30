using Barbershop.Domain;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Persistence
{
    public class BarbershopContext : DbContext
    {
        public DbSet<Record> Records { get; set; }
        public DbSet<Service> Services { get; set; }

        public BarbershopContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=barbershopdata.db");
        }

    }
}
