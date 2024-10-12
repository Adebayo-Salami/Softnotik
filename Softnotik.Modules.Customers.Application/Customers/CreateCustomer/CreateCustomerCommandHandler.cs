using Softnotik.Modules.CustomerModule.Application.Abstractions.DataAccess;
using Softnotik.Modules.CustomerModule.Domain.Customers;
using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Shared.Application.Messaging;
using Softnotik.Shared.Domain;

namespace Softnotik.Modules.CustomerModule.Application.Customers.CreateCustomer
{
    internal sealed class CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork) : ICommandHandler<CreateCustomerCommand, Guid>
    {
        public async Task<Result<Guid>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = Customer.Create(request.Fullname, request.Email, request.Address, request.Zipcode, request.Phone);
            await customerRepository.InsertAsync(customer);
            await unitOfWork.SaveChangesAsync();
            return customer.Id;
        }
    }
}
