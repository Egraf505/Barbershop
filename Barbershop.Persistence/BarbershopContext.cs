using Barbershop.Domain;
using Microsoft.EntityFrameworkCore;

namespace Barbershop.Persistence
{
    public class BarbershopContext : DbContext
    {
        DbSet<Record> Records { get; set; }
        DbSet<Service> Services { get; set; }

        public BarbershopContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=barbershopdata.db");
        }

    }
}
