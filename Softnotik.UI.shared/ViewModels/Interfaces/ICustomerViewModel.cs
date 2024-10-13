using Softnotik.UI.Shared.ViewModels.CustomerViewModels;

namespace Softnotik.UI.Shared.ViewModels.Interfaces
{
    public interface ICustomerViewModel
    {
        public IEnumerable<CustomerVM> Customers { get; }
        public int CustomersCount { get; }


        // The methods are gonna load the actual customers
        public Task<CustomerVM> GetById();
        public Task GetAll();
        public Task<Guid> Create();
        public Task<CustomerVM> Update();
        public Task<bool> Delete(Guid id);
    }
}
