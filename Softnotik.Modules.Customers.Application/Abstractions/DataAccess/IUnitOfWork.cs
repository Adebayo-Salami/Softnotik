namespace Softnotik.Modules.CustomerModule.Application.Abstractions.DataAccess
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
