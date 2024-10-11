#nullable disable

namespace Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels
{
    public class CustomerVM
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Zipcode { get; private set; }
        public string Phone { get; private set; }

        public static implicit operator CustomerVM(Customer model)
        {
            return model == null
                ? null
                : new CustomerVM
                {
                    Id = model.Id,
                    FullName = model.FullName,
                    Email = model.Email,
                    Address = model.Address,
                    Zipcode = model.Zipcode,
                    Phone = model.Phone
                };
        }
    }
}
