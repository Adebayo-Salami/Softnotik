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

        public async Task<CustomerVM> GetById(Guid id)
        {
            return await _httpClient.GetAsync<CustomerVM>("customers/" + id);
        }

        public async Task<IEnumerable<CustomerVM>> GetAll()
        {
            return await _httpClient.GetAsync<List<CustomerVM>>("customers");
        }

        public async Task<Guid> Create(CreateCustomerVM model)
        {
            return await _httpClient.PostAsync<Guid>("customers", model);
        }

        public async Task<CustomerVM> Update(Guid id, UpdateCustomerVM model)
        {
            return await _httpClient.PutAsync<CustomerVM>("customers/" + id, model);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _httpClient.DeleteAsync<bool>("customers/" + id);
        }
    }
}
