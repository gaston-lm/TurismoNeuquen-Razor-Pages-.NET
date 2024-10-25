using System;
using Microsoft.EntityFrameworkCore;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Data
{
    public class PoiContext : DbContext
    {
        public PoiContext(DbContextOptions<PoiContext> options) : base(options)
        {

        }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attraction>().HasData(
                new PointOfInterest("Monumento a San Martín", "Monumento al General San Martín", -38.9517, -68.0592),
                new PointOfInterest("Museo Nacional", "Museo en Neuquén", -38.952, -68.060)
            );
        }
    }
}