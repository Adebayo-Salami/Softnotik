using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;

namespace Softnotik.Modules.CustomerModule.Domain.Customers.IRepository
{
    public interface ICustomerRepository
    {
        Task<CustomerVM?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<CustomerVM?> GetByEmailAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<CustomerVM>> GetAllAsync(CancellationToken cancellationToken = default);
        Task InsertAsync(Customer customer);
    }
}
