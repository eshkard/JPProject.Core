using JPProject.Domain.Core.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace JPProject.Admin.Application.Configuration
{
    internal static class DomainEventsBootStrapper
    {
        public static IServiceCollection AddDomainEventsServices(this IServiceCollection services)
        {
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            return services;
        }
    }
}
