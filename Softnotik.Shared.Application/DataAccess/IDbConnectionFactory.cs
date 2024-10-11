using System.Data.Common;

namespace Softnotik.Shared.Application.DataAccess
{
    public interface IDbConnectionFactory
    {
        ValueTask<DbConnection> OpenConnectionAsync();
    }
}
