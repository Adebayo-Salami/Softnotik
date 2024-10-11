using Softnotik.Shared.Domain;

namespace Softnotik.Modules.CustomerModule.Domain.Customers.Events
{
    public sealed class CustomerCreatedDomainEvent(Guid customerId) : DomainEvent
    {
        public Guid CustomerId { get; init; } = customerId;
    }
}
