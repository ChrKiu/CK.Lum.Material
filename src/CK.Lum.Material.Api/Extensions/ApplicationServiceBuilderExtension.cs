using CK.Lum.Material.Application.Interfaces;
using CK.Lum.Material.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CK.Lum.Material.Api.Extensions
{
    internal static class ApplicationServiceBuilderExtension
    {
        /// <summary>
        /// Adds all services to the dependency container
        /// </summary>
        internal static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMaterialService, MaterialService>();
            return services;
        } 
    }
}
