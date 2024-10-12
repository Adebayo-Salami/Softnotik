using MassTransit;
using Softnotik.Modules.CustomerModule.Application.Abstractions.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Softnotik.Modules.CustomerModule.Infrastructure.Database
{
    public sealed class CustomerModuleDbContext(DbContextOptions<CustomerModuleDbContext> options) : DbContext(options), IUnitOfWork
    {
    }
}
