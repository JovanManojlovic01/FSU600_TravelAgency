using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;

namespace TravelAgency.Repositories
{
    public class BookingRepository
    {
        private IDbContextFactory<AppDbContext> _contextFactory;

        public BookingRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Booking>> GetBookingsAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Destination)
                .ToListAsync();
        }

        public async Task<Booking?> GetBookingbyIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Destination)
                .FirstOrDefaultAsync(b => b.ID == id);
        }

        public async Task AddBookingAsync(Booking booking)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Bookings.Add(booking);
            await context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var booking = await context.Bookings
                .Include(b => b.Customer)
                .Include(b => b.Destination)
                .FirstOrDefaultAsync(b => b.ID == id);

            if (booking != null)
            {
                context.Bookings.Remove(booking);
                await context.SaveChangesAsync();
                Console.WriteLine($"Booking with ID {id} successfully deleted.");
            }
            else
            {
                Console.WriteLine($"Booking with ID {id} not found.");
            }
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            using var context = _contextFactory.CreateDbContext();

            var existingBooking = await context.Bookings
                .FirstOrDefaultAsync(b => b.ID == booking.ID);

            if (existingBooking != null)
            {
                existingBooking.customerID = booking.customerID;
                existingBooking.destinationID = booking.destinationID;
                existingBooking.bookingTime = booking.bookingTime;

                await context.SaveChangesAsync();
            }
        }
    }
}
