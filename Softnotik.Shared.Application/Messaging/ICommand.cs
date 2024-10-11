using MediatR;
using Softnotik.Shared.Domain;

namespace Softnotik.Shared.Application.Messaging
{
    public interface ICommand : IRequest<Result>, IBaseCommand;
    public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand;
    public interface IBaseCommand;
}
