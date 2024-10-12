using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Shared.Domain;

namespace Softnotik.Modules.CustomerModule.Domain.Customers.Events
{
    public sealed class CustomerUpdatedDomainEvent(Customer customer) : DomainEvent
    {
        public CustomerVM Customer { get; init; } = customer;
    }
}
