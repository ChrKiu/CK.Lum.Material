using CK.Lum.Material.Api.Configurations;
using CK.Lum.Material.Data.RavenDb;
using Microsoft.Extensions.DependencyInjection;

namespace CK.Lum.Material.Api.Extensions
{
    internal static class ConfigurationServiceBuilderExtension
    {
        /// <summary>
        /// Adds all configurations for the other layers to the dependency container
        /// </summary>
        internal static IServiceCollection ConfigureConfigurations(this IServiceCollection services)
        {
            services.AddSingleton<IRavenDbConfiguration, RavenDbConfiguration>();
            return services;
        }
    }
}
