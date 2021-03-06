using Microsoft.Extensions.DependencyInjection;

namespace JPProject.Admin.Domain.Interfaces
{
    public interface IJpProjectAdminBuilder
    {
        /// <summary>Gets the services.</summary>
        /// <value>The services.</value>
        IServiceCollection Services { get; }
    }
}