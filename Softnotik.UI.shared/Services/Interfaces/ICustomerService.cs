using Softnotik.UI.Shared.ViewModels.CustomerViewModels;

namespace Softnotik.UI.Shared.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<CustomerVM> GetById(Guid id);
        Task<IEnumerable<CustomerVM>> GetAll();
        Task<Guid> Create(CreateCustomerVM model);
        Task<CustomerVM> Update(Guid id, UpdateCustomerVM model);
        Task<bool> Delete(Guid id);
    }
}
