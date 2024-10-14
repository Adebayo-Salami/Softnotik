#nullable disable

namespace Softnotik.UI.Shared.ViewModels.CustomerViewModels
{
    public class UpdateCustomerVM
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? ZipCode { get; set; }
        public string? Phone { get; set; }

        public static implicit operator UpdateCustomerVM(CreateCustomerVM model)
        {
            return model == null
                ? null
                : new UpdateCustomerVM
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Address = model.Address,
                    ZipCode = model.ZipCode,
                    Phone = model.Phone
                };
        }
    }
}
