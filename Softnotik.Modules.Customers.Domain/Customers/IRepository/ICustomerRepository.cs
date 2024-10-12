using Softnotik.Modules.CustomerModule.Domain.Customers.ViewModels;

namespace Softnotik.Modules.CustomerModule.Domain.Customers.IRepository
{
    public interface ICustomerRepository
    {
        Task<Customer?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<Customer?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);
        Task<IEnumerable<Customer>> GetAllAsync(CancellationToken cancellationToken = default);
        Task InsertAsync(Customer customer);
        Task<Customer> UpdateAsync(Customer customer, CancellationToken cancellationToken = default);
        Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
