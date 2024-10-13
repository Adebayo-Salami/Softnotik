#nullable disable

namespace Softnotik.UI.Shared.ViewModels.CustomerViewModels
{
    public class CustomerVM
    {
        public Guid Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Address { get; private set; }
        public string Zipcode { get; private set; }
        public string Phone { get; private set; }
    }
}
