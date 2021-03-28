using CK.Lum.Material.Application.Interfaces;
using CK.Lum.Material.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CK.Lum.Material.Api.Extensions
{
    internal static class ApplicationServiceBuilderExtension
    {
        internal static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IMaterialService, MaterialService>();
            return services;
        } 
    }
}
