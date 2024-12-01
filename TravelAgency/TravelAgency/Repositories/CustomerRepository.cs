using Microsoft.EntityFrameworkCore;
using TravelAgency.Models;

namespace TravelAgency.Repositories
{
    public class CustomerRepository
    {
        private IDbContextFactory<AppDbContext> _contextFactory;

        public CustomerRepository(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<List<Customer>> GetCustomersAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer?> GetCustomerByIdAsync (int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.Customers.FindAsync(id);
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Customers.Add(customer);
            await context.SaveChangesAsync();
        }
    }
}
