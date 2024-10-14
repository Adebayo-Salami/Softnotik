using Softnotik.UI.Shared.ViewModels.Interfaces;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Softnotik.UI.Shared.ViewModels.CustomerViewModels
{
    public class CreateCustomerVM
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
