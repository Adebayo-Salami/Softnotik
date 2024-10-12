using FluentValidation;

namespace Softnotik.Modules.CustomerModule.Application.Customers.CreateCustomer
{
    internal sealed class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(c => c.Fullname).NotEmpty();
            RuleFor(c => c.Email).NotEmpty();
            RuleFor(c => c.Address).NotEmpty();
            RuleFor(c => c.Zipcode).NotEmpty();
            RuleFor(c => c.Phone).NotEmpty();
        }
    }
}
