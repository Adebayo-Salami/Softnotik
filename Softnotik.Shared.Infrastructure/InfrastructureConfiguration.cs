using MassTransit;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Softnotik.Shared.Application.Caching;
using Softnotik.Shared.Application.DataAccess;
using Softnotik.Shared.Application.EventBus;
using Softnotik.Shared.Infrastructure.Caching;
using Softnotik.Shared.Infrastructure.Data;
using Softnotik.Shared.Infrastructure.Interceptors;
using System.Data.Common;

namespace Softnotik.Shared.Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, Action<IRegistrationConfigurator>[] moduleConfigureConsumers, string databaseConnectionString)
        {
            var factory = SqlClientFactory.Instance;
            DbDataSource dataSource = factory.CreateDataSource(databaseConnectionString);

            services.TryAddSingleton(dataSource);
            services.TryAddScoped<IDbConnectionFactory, DbConnectionFactory>();
            services.TryAddSingleton<PublishDomainEventsInterceptor>();
            services.AddDistributedMemoryCache();
            services.TryAddSingleton<ICacheService, CacheService>();
            services.TryAddSingleton<IEventBus, EventBus.EventBus>();

            services.AddMassTransit(configure =>
            {
                foreach (Action<IRegistrationConfigurator> configureConsumer in moduleConfigureConsumers)
                {
                    configureConsumer(configure);
                }

                configure.SetKebabCaseEndpointNameFormatter();

                configure.UsingInMemory((context, cfg) =>
                {
                    cfg.ConfigureEndpoints(context);
                });
            });

            return services;
        }
    }
}
