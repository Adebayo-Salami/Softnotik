using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Softnotik.Modules.CustomerModule.Application.Customers.CreateCustomer;
using Softnotik.Shared.Domain;
using Softnotik.Shared.Presentation.Endpoints;
using Softnotik.Shared.Presentation.Results;

#nullable disable

namespace Softnotik.Modules.CustomerModule.Presentation.Customers
{
    internal sealed class CreateCustomer : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapPost("customers", async (Request request, ISender sender) =>
            {
                Result<Guid> result = await sender.Send(new CreateCustomerCommand(request.FullName, request.Email, request.Address, request.ZipCode, request.Phone));
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Customers);
        }

        internal sealed class Request
        {
            public string FullName { get; init; }
            public string Email { get; init; }
            public string Address { get; init; }
            public string ZipCode { get; init; }
            public string Phone { get; init; }
        }
    }
}
