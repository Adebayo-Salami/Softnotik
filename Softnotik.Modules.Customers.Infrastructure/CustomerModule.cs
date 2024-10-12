using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Modules.CustomerModule.Infrastructure.Database;
using Softnotik.Shared.Presentation.Endpoints;
using Microsoft.EntityFrameworkCore;
using Softnotik.Shared.Infrastructure.Interceptors;
using Softnotik.Modules.CustomerModule.Application.Abstractions.DataAccess;
using Softnotik.Modules.CustomerModule.Infrastructure.Customers;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Softnotik.Modules.CustomerModule.Infrastructure
{
    public static class CustomerModule
    {
        public static IServiceCollection AddEventsModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEndpoints(Presentation.AssemblyReference.Assembly);
            services.AddInfrastructure(configuration);
            return services;
        }

        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            string databaseConnectionString = configuration.GetConnectionString("Database")!;
            services.AddDbContext<CustomerModuleDbContext>((sp, options) =>
                options
                    .UseSqlServer(
                        databaseConnectionString,
                        sqlOptions => sqlOptions
                            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Customers))
                    .UseSnakeCaseNamingConvention()
                    .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<CustomerModuleDbContext>());
            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
