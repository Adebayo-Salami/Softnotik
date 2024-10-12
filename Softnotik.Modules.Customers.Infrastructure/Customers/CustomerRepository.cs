using Microsoft.EntityFrameworkCore;
using Softnotik.Modules.CustomerModule.Domain.Customers;
using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Modules.CustomerModule.Infrastructure.Database;

namespace Softnotik.Modules.CustomerModule.Infrastructure.Customers
{
    internal sealed class CustomerRepository(CustomerModuleDbContext context) : ICustomerRepository
    {
        public async Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await context.Customers.AsNoTracking().FirstOrDefaultAsync((x) => x.Id == id, cancellationToken);
        }

        public async Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await context.Customers.AsNoTracking().FirstOrDefaultAsync((x) => x.Email == email, cancellationToken);
        }

        public async Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await context.Customers.AsNoTracking().ToListAsync(cancellationToken);
        }

        public async Task InsertAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
        }

        public async Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default)
        {
            context.Customers.Update(customer);
            return customer;
        }

        public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await context.Customers.AsNoTracking().Where((x) => x.Id == id).ExecuteDeleteAsync(cancellationToken);
        }
    }
}
