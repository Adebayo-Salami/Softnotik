using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Softnotik.UI.Shared.Logging;
using Softnotik.UI.Shared.Models;
using Softnotik.UI.Shared.Services;
using Softnotik.UI.Shared.Services.Interfaces;
using Softnotik.UI.Shared.ViewModels;
using Softnotik.UI.Shared.ViewModels.CustomerViewModels;
using Softnotik.UI.Shared.ViewModels.Interfaces;

namespace Softnotik.UI.Shared.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddSoftnotikCustomerModule(this IServiceCollection services, ApplicationSettings applicationSettings)
        {
            // blazored services
            services.AddBlazoredToast();
            services.AddBlazoredLocalStorage();

            // configuring http clients
            services.AddScoped(_ => new HttpClient { BaseAddress = new Uri(applicationSettings.BaseAddress) });

            // transactional named http clients
            var clientConfigurator = void (HttpClient client) => client.BaseAddress = new Uri(applicationSettings.BaseAddress);
            services.AddScoped<ICustomerService, CustomerService>();

            // Add Settings
            services.AddSingleton<ISettingsViewModel, SettingsViewModel>();

            // logging
            services.AddLogging(logging => logging.SetMinimumLevel(LogLevel.Error));
            services.AddSingleton<LogQueue>();
            services.AddSingleton<LogReader>();
            services.AddSingleton<LogWriter>();
            services.AddSingleton<ILoggerProvider, ApplicationLoggerProvider>();
            services.AddHttpClient("LoggerJob", c => c.BaseAddress = new Uri(applicationSettings.BaseAddress));
            services.AddSingleton<LoggerJob>();

            return services;
        }
    }
}
