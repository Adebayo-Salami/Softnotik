using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Shared.Application.Messaging;

namespace Softnotik.Modules.CustomerModule.Application.Customers.UpdateCustomer
{
    public sealed record UpdateCustomerCommand(Guid CustomerId, string? Fullname, string? Email, string? Address, string? Zipcode, string? Phone) : ICommand<CustomerVM>;
}
