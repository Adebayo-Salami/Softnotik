using Microsoft.EntityFrameworkCore;
using Softnotik.Modules.CustomerModule.Domain.Customers;
using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Modules.CustomerModule.Infrastructure.Database;

namespace Softnotik.Modules.CustomerModule.Infrastructure.Customers
{
    internal sealed class CustomerRepository(CustomerModuleDbContext context) : ICustomerRepository
    {
        public async Task<CustomerVM?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await context.Customers.AsNoTracking().FirstOrDefaultAsync((x) => x.Id == id, cancellationToken);
        }

        public async Task<CustomerVM?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            return await context.Customers.AsNoTracking().FirstOrDefaultAsync((x) => x.Email == email, cancellationToken);
        }

        public async Task<IEnumerable<CustomerVM>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var customers = await context.Customers.AsNoTracking().ToListAsync(cancellationToken);
            return customers.Select(x => (CustomerVM)x);
        }

        public async Task InsertAsync(Customer customer)
        {
            await context.Customers.AddAsync(customer);
        }
    }
}
