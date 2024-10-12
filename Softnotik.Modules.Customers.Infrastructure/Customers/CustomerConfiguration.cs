using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Softnotik.Modules.CustomerModule.Domain.Customers;

namespace Softnotik.Modules.CustomerModule.Infrastructure.Customers
{
    internal sealed class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            // Add Customer Model SPecific Configurations Here
        }
    }
}
