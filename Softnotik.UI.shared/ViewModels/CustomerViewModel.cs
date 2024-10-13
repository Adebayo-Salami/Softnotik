using Softnotik.UI.Shared.Extensions;
using Softnotik.UI.Shared.ViewModels.CustomerViewModels;
using Softnotik.UI.Shared.ViewModels.Interfaces;

namespace Softnotik.UI.Shared.ViewModels
{
    public class CustomerViewModel : ICustomerViewModel
    {
        private readonly HttpClient _httpClient;
        public IEnumerable<CustomerVM> Customers { get; private set; } = [];
        public int CustomersCount { get; private set; } = 1;

        public CustomerViewModel(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<CustomerVM> GetById()
        {
            throw new NotImplementedException();
        }

        public async Task LoadAllCustomers()
        {
            Customers = await _httpClient.GetAsync<IEnumerable<CustomerVM>>("customers");
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
