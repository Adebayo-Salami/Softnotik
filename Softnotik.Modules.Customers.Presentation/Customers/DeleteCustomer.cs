using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Softnotik.Modules.CustomerModule.Application.Customers.DeleteCustomer;
using Softnotik.Shared.Presentation.Endpoints;
using Softnotik.Shared.Presentation.Results;

namespace Softnotik.Modules.CustomerModule.Presentation.Customers
{
    internal sealed class DeleteCustomer : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapDelete("customers/{id}", async (Guid id, ISender sender) =>
            {
                var result = await sender.Send(new DeleteCustomerCommand(id));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Customers);
        }
    }
}
