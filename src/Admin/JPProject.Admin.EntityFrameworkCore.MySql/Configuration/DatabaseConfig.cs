using JPProject.Admin.Domain.Interfaces;
using JPProject.Admin.Infra.Data.Configuration;
using JPProject.Admin.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reflection;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DatabaseConfig
    {
        public static IJpProjectAdminBuilder WithMySql(this IJpProjectAdminBuilder services, string connectionString, JpDatabaseOptions options = null)
        {
            var migrationsAssembly = typeof(DatabaseConfig).GetTypeInfo().Assembly.GetName().Name;
            services.Services.AddEntityFrameworkMySql().AddAdminContext(options => options.UseMySql(connectionString, sql => sql.MigrationsAssembly(migrationsAssembly)), options);

            return services;
        }

        public static IJpProjectAdminBuilder WithMySql(this IJpProjectAdminBuilder services, Action<DbContextOptionsBuilder> optionsAction, JpDatabaseOptions options = null)
        {
            services.Services.AddAdminContext(optionsAction, options);

            return services;
        }
    }
}