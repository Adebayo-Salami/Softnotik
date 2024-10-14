using Softnotik.UI.Shared.Extensions;
using Softnotik.UI.Shared.Services.Interfaces;
using Softnotik.UI.Shared.ViewModels.CustomerViewModels;

namespace Softnotik.UI.Shared.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly HttpClient _httpClient;
        private readonly CustomerVM[] DummyData = [
            new ()
            {
                Id = Guid.Parse("9d30327b-2fbd-4aef-a803-87b7d5c67c5e"),
                FullName = "Dummy Customer A",
                Email = "dummy@gmail.com",
                Address = "Testing",
                Zipcode = "1212121",
                Phone = "080909091",
            },
            new ()
            {
                Id = Guid.Parse("5773d095-eabc-4859-9482-036fe5bd79ca"),
                FullName = "Dummy Customer B",
                Email = "dummyB@gmail.com",
                Address = "Testing 3",
                Zipcode = "121212113",
                Phone = "0809090912",
            }
         ];

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
            return DummyData;
            return await _httpClient.GetAsync<IEnumerable<CustomerVM>>("customers");
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
