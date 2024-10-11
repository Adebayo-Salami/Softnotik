using Dapper;
using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Shared.Application.Messaging;
using Softnotik.Shared.Domain;

namespace Softnotik.Modules.CustomerModule.Application.Customers.GetAllCustomers
{
    internal sealed class GetAllCustomersQueryHandler(ICustomerRepository customerRepository) : IQueryHandler<GetAllCustomersQuery, IEnumerable<CustomerVM>>
    {
        public async Task<Result<IEnumerable<CustomerVM>>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = await customerRepository.GetAllAsync(cancellationToken);
            return customers.AsList();
        }
    }
}
