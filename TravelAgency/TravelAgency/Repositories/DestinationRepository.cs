using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;

namespace TravelAgency.Repositories
{
    public class DestinationRepository
    {
        private IDbContextFactory<AppDbContext> _contextFactory;

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
            return await context.Destinations.FindAsync(id);
        }

        public async Task AddDestinationAsync(Destination destination)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Destinations.Add(destination);
            await context.SaveChangesAsync();
        }

        public async Task DeleteDestinationAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var destination = await context.Destinations.FindAsync(id);
            if (destination != null)
            {
                context.Destinations.Remove(destination);
                await context.SaveChangesAsync(true);
            }
        }

        public async Task UpdateDestinationAsync(Destination destination)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Destinations.Update(destination);

            await context.SaveChangesAsync();
        }
    }
}
