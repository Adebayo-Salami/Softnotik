using FluentValidation;

namespace Softnotik.Modules.CustomerModule.Application.Customers.UpdateCustomer
{
    internal sealed class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
    {
        public UpdateCustomerCommandValidator()
        {
            RuleFor(c => c.CustomerId).NotEmpty();
        }
    }
}
