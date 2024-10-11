using MediatR;
using Softnotik.Shared.Domain;

namespace Softnotik.Shared.Application.Messaging
{
    public interface IQuery<TResponse> : IRequest<Result<TResponse>>;
}
