using Softnotik.UI.Shared.ViewModels.CustomerViewModels;
using Softnotik.UI.Shared.ViewModels.Interfaces;

namespace Softnotik.UI.Shared.ViewModels
{
    public class CustomerViewModel : ICustomerViewModel
    {
        private readonly HttpClient _httpClient;
        public IEnumerable<CustomerVM> Contacts { get; private set; } = [];
        public int CustomersCount { get; private set; } = 1;

        public IEnumerable<CustomerVM> Customers => throw new NotImplementedException();

        public CustomerViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<CustomerVM> GetById()
        {
            throw new NotImplementedException();
        }

        public Task GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Guid> Create()
        {
            throw new NotImplementedException();
        }

        public Task<CustomerVM> Update()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
