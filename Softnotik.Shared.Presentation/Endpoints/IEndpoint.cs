using Microsoft.AspNetCore.Routing;

namespace Softnotik.Shared.Presentation.Endpoints
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
