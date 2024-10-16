﻿using Microsoft.EntityFrameworkCore;
using Softnotik.Modules.CustomerModule.Infrastructure.Database;

namespace Softnotik.Extensions
{
    internal static class MigrationExtensions
    {
        internal static void ApplyMigrations(this IApplicationBuilder app)
        {
            using IServiceScope scope = app.ApplicationServices.CreateScope();

            ApplyMigration<CustomerModuleDbContext>(scope);
        }

        private static void ApplyMigration<TDbContext>(IServiceScope scope) where TDbContext : DbContext
        {
            using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();
            context.Database.Migrate();
        }
    }
}
