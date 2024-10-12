using Softnotik.Shared.Application.Messaging;

namespace Softnotik.Modules.CustomerModule.Application.Customers.DeleteCustomer
{
    public sealed record DeleteCustomerCommand(Guid CustomerId) : ICommand<bool>;
}
