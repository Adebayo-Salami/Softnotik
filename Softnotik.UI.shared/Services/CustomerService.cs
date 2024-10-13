using Softnotik.UI.Shared.Extensions;
using Softnotik.UI.Shared.Services.Interfaces;
using Softnotik.UI.Shared.ViewModels.CustomerViewModels;

namespace Softnotik.UI.Shared.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;

        public CustomerService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task<CustomerVM> GetById()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<CustomerVM>> GetAll()
        {
            var dd = await _httpClient.GetAsync<IEnumerable<CustomerVM>>("customers");
            return await _httpClient.GetAsync<IEnumerable<CustomerVM>>("customers");
        }

        public Task<Guid> Create(CreateCustomerVM model)
        {
            throw new NotImplementedException();
        }

        public Task<CustomerVM> Update(UpdateCustomerVM model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
