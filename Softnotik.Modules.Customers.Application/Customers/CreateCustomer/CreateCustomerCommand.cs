using Softnotik.Shared.Application.Messaging;

namespace Softnotik.Modules.CustomerModule.Application.Customers.CreateCustomer
{
    public sealed record CreateCustomerCommand(string Fullname, string Email, string Address, string Zipcode, string Phone) : ICommand<Guid>;
}
