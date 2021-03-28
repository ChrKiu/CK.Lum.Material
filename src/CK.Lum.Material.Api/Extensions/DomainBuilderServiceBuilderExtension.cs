using CK.Lum.Material.Domain.Builder;
using CK.Lum.Material.Domain.Models.MaterialAggregate;
using Microsoft.Extensions.DependencyInjection;

namespace CK.Lum.Material.Api.Extensions
{
    internal static class DomainBuilderServiceBuilderExtension
    {
        /// <summary>
        /// Adds all builders for the domain models to the dependency container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static IServiceCollection ConfigureDomainBuilders(this IServiceCollection services)
        {
            services.AddScoped<IMaterialBuilder, MaterialBuilder>();
            return services;
        }
    }
}
