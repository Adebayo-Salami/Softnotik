using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Shared.Application.Messaging;

namespace Softnotik.Modules.CustomerModule.Application.Customers.GetAllCustomers
{
    public sealed record GetAllCustomersQuery() : IQuery<List<CustomerVM>>;
}
