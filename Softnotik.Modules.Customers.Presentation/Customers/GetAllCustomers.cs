using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Softnotik.Modules.CustomerModule.Application.Customers.GetAllCustomers;
using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;
using Softnotik.Shared.Domain;
using Softnotik.Shared.Presentation.Endpoints;
using Softnotik.Shared.Presentation.Results;

namespace Softnotik.Modules.CustomerModule.Presentation.Customers
{
    internal sealed class GetAllCustomers : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("customers", async (ISender sender) =>
            {
                Result<List<CustomerVM>> result = await sender.Send(new GetAllCustomersQuery());
                return result.Match(Results.Ok, ApiResults.Problem);
            })
            .WithTags(Tags.Customers);
        }
    }
}
