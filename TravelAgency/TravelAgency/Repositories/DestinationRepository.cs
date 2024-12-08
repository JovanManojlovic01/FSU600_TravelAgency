using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;

namespace TravelAgency.Repositories
{
    public class DestinationRepository
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public DestinationRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Destination>> GetDestinationsAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Destinations.ToListAsync();
        }

        public async Task<Destination?> GetDestinationByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Destinations.AsNoTracking().FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddDestinationAsync(Destination destination)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Destinations.Add(destination);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding destination: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteDestinationAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var destination = await context.Destinations.FindAsync(id);
            if (destination != null)
            {
                context.Destinations.Remove(destination);
                try
                {
                    await context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error deleting destination: {ex.Message}");
                    throw;
                }
            }
        }

        public async Task UpdateDestinationAsync(Destination destination)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Destinations.Update(destination);
            try
            {
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating destination: {ex.Message}");
                throw;
            }
        }
    }
}
