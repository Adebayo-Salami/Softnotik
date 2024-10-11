using Microsoft.Extensions.DependencyInjection;
using Softnotik.Shared.Application.Behaviours;
using System.Reflection;
using FluentValidation;

namespace Softnotik.Shared.Application
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssemblies(moduleAssemblies);

                config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
                config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
            });

            services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

            return services;
        }
    }
}
