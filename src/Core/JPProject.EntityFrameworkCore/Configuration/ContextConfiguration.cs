using JPProject.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace JPProject.EntityFrameworkCore.Configuration
{
    public static class ContextConfiguration
    {
        public static IServiceCollection AddEventStoreContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction, EventStoreMigrationOptions options = null)
        {
            services.AddDbContext<EventStoreContext>(optionsAction);

            if (options != null && options.Migrate)
                DbMigrationHelpers.CheckDatabases(services.BuildServiceProvider()).Wait();

            return services;
        }
    }
}
