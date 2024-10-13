using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Softnotik.UI.Shared.ViewModels.CustomerViewModels
{
    public class CreateCustomerVM
    {
        [Required]
        public string FullName { get; init; }
        [Required]
        public string Email { get; init; }
        [Required]
        public string Address { get; init; }
        [Required]
        public string ZipCode { get; init; }
        [Required]
        public string Phone { get; init; }
    }
}
