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
            // Define the inheritance hierarchy for PointOfInterest (if applicable)
            modelBuilder.Entity<PointOfInterest>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Attraction>("Attraction")
                .HasValue<Event>("Event");

            // Configure the relationship between PointOfInterest and User
            modelBuilder.Entity<PointOfInterest>()
                .HasOne(p => p.User)
                .WithMany(u => u.PointsOfInterest)
                .HasForeignKey(p => p.UserId);

            base.OnModelCreating(modelBuilder);
        }

    }
}