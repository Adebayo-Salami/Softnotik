using Softnotik.Shared.Domain;

namespace Softnotik.Modules.CustomerModule.Domain.Customers
{
    public static class CustomerErrors
    {
        public static Error NotFound(Guid categoryId) => Error.NotFound("Customer.NotFound", $"The customer with the identifier {categoryId} was not found");

        public static readonly Error AlreadyArchived = Error.Problem("Customer.AlreadyExists", "The customer with this email already exists");
    }
}
