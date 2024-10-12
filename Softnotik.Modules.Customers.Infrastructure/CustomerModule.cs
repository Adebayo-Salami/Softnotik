using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Softnotik.Modules.CustomerModule.Domain.Customers.IRepository;
using Softnotik.Shared.Presentation.Endpoints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            services.AddDbContext<EventsDbContext>((sp, options) =>
                options
                    .UseNpgsql(
                        databaseConnectionString,
                        npgsqlOptions => npgsqlOptions
                            .MigrationsHistoryTable(HistoryRepository.DefaultTableName, Schemas.Events))
                    .UseSnakeCaseNamingConvention()
                    .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>()));

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<EventsDbContext>());

            services.AddScoped<ICustomerRepository, CustomerRepository>();
        }
    }
}
