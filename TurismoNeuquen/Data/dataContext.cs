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
            base.OnModelCreating(modelBuilder);

            // Define inheritance hierarchy for PointOfInterest
            modelBuilder.Entity<PointOfInterest>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Attraction>("Attraction")
                .HasValue<Event>("Event");

            // Relationship between PointOfInterest and User
            modelBuilder.Entity<PointOfInterest>()
                .HasOne(p => p.User)
                .WithMany(u => u.PointsOfInterest)
                .HasForeignKey(p => p.UserId);

            // Seed Users
            modelBuilder.Entity<Admin>().HasData(
                new Admin { Id = 1, Username = "Nico", Password = "1234" },
                new Admin { Id = 2, Username = "Martin", Password = "1234" }
            );

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Username = "Lucas", Password = "1234" }
            );

            // Seed Attractions
            modelBuilder.Entity<Attraction>().HasData(
                new Attraction
                {
                    Id = 1,
                    Name = "Ruta de los 7 lagos",
                    Description = "Descubra por qué Bariloche es famoso por sus lagos en una excursión de día completo por uno de los paisajes más impresionantes de la Patagonia.",
                    Latitude = -40.158010453870496,
                    Longitude = -71.36052169905172,
                    ImageName = "https://media-cdn.tripadvisor.com/media/attractions-splice-spp-720x480/0f/61/95/e1.jpg",
                    State = true,
                    OpenDays = "1111111",
                    OpeningTime = new TimeOnly(9, 0),
                    ClosingTime = new TimeOnly(18, 0),
                    UserId = 1
                },
                new Attraction
                {
                    Id = 2,
                    Name = "Bosque de Arrayanes e Isla Victoria",
                    Description = "Este es uno de los recorridos imperdibles de Bariloche que puedes hacer durante todo el año, independientemente del clima.",
                    Latitude = -40.81580455701655,
                    Longitude = -71.63110350409016,
                    ImageName = "https://media-cdn.tripadvisor.com/media/attractions-splice-spp-720x480/12/4f/72/1f.jpg",
                    State = true,
                    OpenDays = "1111111",
                    OpeningTime = new TimeOnly(6, 0),
                    ClosingTime = new TimeOnly(22, 0),
                    UserId = 1
                },
                new Attraction
                {
                    Id = 3,
                    Name = "Cordillera del Viento",
                    Description = "Compuesta en gran parte por la cordillera de transición de los Andes y la Cordillera del Viento, el norte de la provincia ofrece una experiencia completa de senderismo, arqueología, pesca y fiestas populares; donde la magia se funde con el asombro y la aventura.",
                    Latitude = -36.99903933477934,
                    Longitude = -70.50025756236377,
                    ImageName = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/cf/Volc%C3%A1n_Domuyo.jpg/275px-Volc%C3%A1n_Domuyo.jpg",
                    State = true,
                    OpenDays = "1111100",
                    OpeningTime = new TimeOnly(6, 0),
                    ClosingTime = new TimeOnly(22, 0),
                    UserId = 1
                }
            );

            // Seed Events
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 4,
                    Name = "Festival del vino",
                    Description = "Se toma vino",
                    Latitude = -38.994693327444665,
                    Longitude = -68.40852466855796,
                    ImageName = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSQP2Wx6D7ZuoLSF4xIPWviwknkf2eqM-l2AA&s",
                    State = false,
                    EventDate = new DateTime(2024, 12, 15),
                    UserId = 1
                },
                new Event
                {
                    Id = 5,
                    Name = "Festival de la cerveza",
                    Description = "mucha birra",
                    Latitude = -38.97609030438841,
                    Longitude = -68.05813299637002,
                    ImageName = "https://infonegocios.info/content/images/2023/09/29/410183/cerveza-alumine.jpg",
                    State = true,
                    EventDate = new DateTime(2025, 1, 5),
                    UserId = 1
                }
            );
        }


    }
}