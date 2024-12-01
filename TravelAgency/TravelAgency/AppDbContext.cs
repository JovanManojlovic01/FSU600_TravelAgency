using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;

namespace TravelAgency
{
    public class AppDbContext : DbContext
    {
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public void onModelCreation(ModelBuilder modelBuilder) // Fluent API, make sure that Bookings table is a "junction" table between the customer and destination
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Customer)
                .WithMany(c => c.Bookings)
                .HasForeignKey(b => b.customerID);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Destination)
                .WithMany(d => d.Bookings)
                .HasForeignKey(b =>b.destinationID);
        }
    }
}
