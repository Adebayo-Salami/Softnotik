using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Shared.Application.Messaging;
using Softnotik.Shared.Domain;

namespace Softnotik.Modules.CustomerModule.Application.Customers.DeleteCustomer
{
    internal sealed class DeleteCustomerCommandHandler(ICustomerRepository customerRepository) : ICommandHandler<DeleteCustomerCommand, bool>
    {
        public async Task<Result<bool>> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            return await customerRepository.DeleteAsync(request.CustomerId) > 0;
        }
    }
}
