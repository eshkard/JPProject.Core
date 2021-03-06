using IdentityServer4.EntityFramework.Options;
using JPProject.EntityFrameworkCore.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using JPProject.Admin.Infra.Data.Context;
using JPProject.Admin.Infra.Data.UoW;
using JPProject.Domain.Core.Events;
using JPProject.Domain.Core.Interfaces;
using JPProject.EntityFrameworkCore.EventSourcing;
using JPProject.EntityFrameworkCore.Repository;

namespace JPProject.Admin.Infra.Data.Configuration
{
    public static class ContextConfiguration
    {
        public static IServiceCollection AddAdminContext(this IServiceCollection services, Action<DbContextOptionsBuilder> optionsAction, JpDatabaseOptions options = null)
        {
            if (options == null)
                options = new JpDatabaseOptions();

            RegisterDatabaseServices(services);


            var operationalStoreOptions = new OperationalStoreOptions();
            services.AddSingleton(operationalStoreOptions);

            var storeOptions = new ConfigurationStoreOptions();
            services.AddSingleton(storeOptions);

            services.AddDbContext<JPProjectAdminUIContext>(optionsAction);
            services.AddDbContext<EventStoreContext>(optionsAction);

            DbMigrationHelpers.CheckDatabases(services.BuildServiceProvider(), options).Wait();

            return services;
        }

        private static void RegisterDatabaseServices(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<JPProjectAdminUIContext>();
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreContext>();
        }
    }
}
