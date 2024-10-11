using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Shared.Application.Messaging;

namespace Softnotik.Modules.CustomerModule.Application.Customers.GetCustomer
{
    public sealed record GetCustomerQuery(Guid CustomerId) : IQuery<CustomerVM>;
}
