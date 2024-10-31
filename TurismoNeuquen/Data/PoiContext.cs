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
            modelBuilder.Entity<PointOfInterest>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Attraction>("Attraction")
                .HasValue<Event>("Event");

            base.OnModelCreating(modelBuilder);
        }
    }
}