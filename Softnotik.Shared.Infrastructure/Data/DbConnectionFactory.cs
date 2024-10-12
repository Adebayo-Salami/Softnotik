using Softnotik.Shared.Application.DataAccess;
using System.Data.Common;

namespace Softnotik.Shared.Infrastructure.Data
{
    internal sealed class DbConnectionFactory(DbDataSource dataSource) : IDbConnectionFactory
    {
        public async ValueTask<DbConnection> OpenConnectionAsync()
        {
            return await dataSource.OpenConnectionAsync();
        }
    }
}
