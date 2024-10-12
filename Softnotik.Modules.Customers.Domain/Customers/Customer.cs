using Softnotik.Modules.CustomerModule.Domain.Customers.Events;
using Softnotik.Shared.Domain;

#nullable disable

namespace Softnotik.Modules.CustomerModule.Domain.Customers
{
    public sealed class Customer : Entity
    {
        private Customer()
        {
        }

        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Zipcode { get; private set; }
        public string Phone { get; private set; }

        public static Customer Create(string Fullname, string Email, string Address, string Zipcode, string Phone)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                FullName = Fullname,
                Email = Email,
                Address = Address,
                Zipcode = Zipcode,
                Phone = Phone,
            };

            customer.Raise(new CustomerCreatedDomainEvent(customer.Id));
            return customer;
        }
    }
}
