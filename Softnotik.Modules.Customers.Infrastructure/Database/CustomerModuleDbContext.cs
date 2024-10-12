using Softnotik.Modules.CustomerModule.Application.Abstractions.DataAccess;
using Microsoft.EntityFrameworkCore;
using Softnotik.Modules.CustomerModule.Domain.Customers;
using Softnotik.Modules.CustomerModule.Infrastructure.Customers;

namespace Softnotik.Modules.CustomerModule.Infrastructure.Database
{
    public sealed class CustomerModuleDbContext(DbContextOptions<CustomerModuleDbContext> options) : DbContext(options), IUnitOfWork
    {
        internal DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Schemas.Customers);

            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
        }
    }
}
