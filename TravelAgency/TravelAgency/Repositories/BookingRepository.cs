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
    }
}
