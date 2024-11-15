using System;
using Microsoft.EntityFrameworkCore;
using TurismoNeuquen.Models;

namespace TurismoNeuquen.Data
{
    public class dataContext : DbContext
    {
        public dataContext(DbContextOptions<dataContext> options) : base(options)
        {

        }
        public DbSet<PointOfInterest> PointsOfInterest { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }

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