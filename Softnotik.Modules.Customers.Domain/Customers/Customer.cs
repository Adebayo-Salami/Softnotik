using Softnotik.Modules.CustomerModule.Domain.Customers.Events;
using Softnotik.Shared.Domain;
using System.Xml.Linq;

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

        public void Update(string fullname, string email, string address, string zipcode, string phone)
        {
            if (!String.IsNullOrWhiteSpace(fullname))
                FullName = fullname;
            if (!String.IsNullOrWhiteSpace(email))
                Email = email;
            if (!String.IsNullOrWhiteSpace(address))
                Address = address;
            if (!String.IsNullOrWhiteSpace(zipcode))
                Zipcode = zipcode;
            if (!String.IsNullOrWhiteSpace(phone))
                Phone = phone;

            Raise(new CustomerUpdatedDomainEvent(this));
        }
    }
}
