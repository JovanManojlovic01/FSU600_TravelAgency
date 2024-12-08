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

        public async Task<Customer?> GetCustomerByIdAsync(int id)
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

        public async Task DeleteCustomerAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var customer = await context.Customers.FindAsync(id);
            if (customer != null)
            {
                context.Customers.Remove(customer);
                await context.SaveChangesAsync(true);
            }
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Customers.Update(customer);
            await context.SaveChangesAsync();
        }
    }
}
