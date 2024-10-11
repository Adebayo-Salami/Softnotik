using MediatR;
using Softnotik.Shared.Domain;

namespace Softnotik.Shared.Application.Messaging
{
    public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>> where TQuery : IQuery<TResponse>;
}
