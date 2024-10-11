using MediatR;

namespace Softnotik.Shared.Domain.Interfaces
{
    public interface IDomainEvent : INotification
    {
        Guid Id { get; }
        DateTime OccurredOnUtc { get; }
    }
}
