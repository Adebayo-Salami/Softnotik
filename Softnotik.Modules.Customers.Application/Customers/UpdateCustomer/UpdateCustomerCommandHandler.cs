using Softnotik.Modules.CustomerModule.Application.Abstractions.DataAccess;
using Softnotik.Modules.CustomerModule.Domain.Customers;
using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Shared.Application.Messaging;
using Softnotik.Shared.Domain;

namespace Softnotik.Modules.CustomerModule.Application.Customers.UpdateCustomer
{
    internal sealed class UpdateCustomerCommandHandlerr(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) : ICommandHandler<UpdateCustomerCommand, CustomerVM>
    {
        public async Task<Result<CustomerVM>> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await customerRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
            {
                return Result.Failure<CustomerVM>(CustomerErrors.NotFound(request.CustomerId));
            }

            customer.Update(request.Fullname, request.Email, request.Address, request.Zipcode, request.Phone);
            await customerRepository.UpdateAsync(customer);
            return (CustomerVM)customer;
        }
    }
}
