using Microsoft.EntityFrameworkCore;

namespace TurismoNeuquen.Models
{
    public class DbMemoria : DbContext
    {
        public DbSet<Attraction> Atracciones { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyDB");
        }
    }
}
