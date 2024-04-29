using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CustomerApp.Models.Entities;
using CustomerApp.Dataa;

namespace CustomerApp.Data
{
    public class CustomerAppContext : DbContext
    {
        public CustomerAppContext() { }
        public CustomerAppContext(DbContextOptions<CustomerAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> User { get; set; } = default!;
        public DbSet<ApplicationUser> Users { get; set; } = default!;
        public DbSet<Room> Rooms { get; set; } = default!;
        public DbSet<Reservasjon> Reservasjoner { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Define keys and other properties for Reservasjon
            modelBuilder.Entity<Reservasjon>(entity =>
            {
                entity.HasKey(e => e.ReservasjonId);
                entity.Property(e => e.ReservasjonId).ValueGeneratedOnAdd();
            });

            // Ensure the table name for Room is set correctly
            modelBuilder.Entity<Room>().ToTable("Room");

            // You can add further configurations for other entities if needed
        }
    }
   

}
