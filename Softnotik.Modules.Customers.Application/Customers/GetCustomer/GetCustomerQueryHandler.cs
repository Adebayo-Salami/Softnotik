using Softnotik.Modules.CustomerModule.Domain.Customers;
using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Shared.Application.Messaging;
using Softnotik.Shared.Domain;

namespace Softnotik.Modules.CustomerModule.Application.Customers.GetCustomer
{
    internal sealed class GetCustomerQueryHandler(ICustomerRepository customerRepository) : IQueryHandler<GetCustomerQuery, CustomerVM>
    {
        public async Task<Result<CustomerVM>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            CustomerVM? customer = await customerRepository.GetByIdAsync(request.CustomerId, cancellationToken);
            if (customer is null)
            {
                return Result.Failure<CustomerVM>(CustomerErrors.NotFound(request.CustomerId));
            }

            return customer;
        }
    }
}
