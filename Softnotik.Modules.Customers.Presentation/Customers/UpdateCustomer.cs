using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Softnotik.Modules.CustomerModule.Application.Customers.UpdateCustomer;
using Softnotik.Shared.Presentation.Endpoints;
using Softnotik.Shared.Presentation.Results;

namespace Softnotik.Modules.CustomerModule.Presentation.Customers
{
    internal sealed class UpdateCustomer : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPut("customers/{id}", async (Guid id, Request request, ISender sender) =>
            {
                var result = await sender.Send(new UpdateCustomerCommand(id, request.FullName, request.Email, request.Address, request.ZipCode, request.Phone));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Customers);
        }

        internal sealed class Request
        {
            public string? FullName { get; init; }
            public string? Email { get; init; }
            public string? Address { get; init; }
            public string? ZipCode { get; init; }
            public string? Phone { get; init; }
        }
    }
}
