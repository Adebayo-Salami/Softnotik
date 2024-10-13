using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Softnotik.UI.Components;
using Softnotik.UI.Shared.Extensions;
using Softnotik.UI.Shared.Models;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

#region Configure Services

// adding client app settings 
builder.Services.AddSingleton<IHostingEnvironment>(new HostingEnvironment() { EnvironmentName = builder.HostEnvironment.Environment });

var applicationSettingsSection = builder.Configuration.GetSection("ApplicationSettings");
builder.Services.Configure<ApplicationSettings[]>(options =>
{
    applicationSettingsSection.Bind(options);
});

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// adding application services
builder.Services.AddSoftnotikCustomerModule(applicationSettingsSection.Get<ApplicationSettings[]>().First());

#endregion

await builder.Build().RunAsync();
