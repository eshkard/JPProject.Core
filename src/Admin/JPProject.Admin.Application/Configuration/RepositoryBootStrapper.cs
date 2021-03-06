using JPProject.Admin.Domain.Interfaces;
using JPProject.Admin.Infra.Data.Configuration;
using JPProject.Admin.Infra.Data.Context;
using JPProject.Admin.Infra.Data.Repository;
using JPProject.Admin.Infra.Data.UoW;
using JPProject.Domain.Core.Events;
using JPProject.Domain.Core.Interfaces;
using JPProject.EntityFrameworkCore.Context;
using JPProject.EntityFrameworkCore.EventSourcing;
using JPProject.EntityFrameworkCore.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace JPProject.Admin.Application.Configuration
{
    internal static class RepositoryBootStrapper
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IPersistedGrantRepository, PersistedGrantRepository>();
            services.AddScoped<IApiResourceRepository, ApiResourceRepository>();
            services.AddScoped<IApiScopeRepository, ApiScopeRepository>();

            services.AddScoped<IIdentityResourceRepository, IdentityResourceRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientSecretRepository, ClientSecretRepository>();
            services.AddScoped<IApiSecretRepository, ApiSecretRepository>();

            services.AddScoped<IClientClaimRepository, ClientClaimRepository>();
            services.AddScoped<IClientPropertyRepository, ClientPropertyRepository>();
            services.AddScoped<IAdimUnitOfWork, UnitOfWork>();
            services.AddScoped<JPProjectAdminUIContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreContext>();
            return services;
        }
    }
}
