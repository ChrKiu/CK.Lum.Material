using CK.Lum.Material.Domain.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace CK.Lum.Material.Api.Extensions
{
    internal static class ValidatorServiceBuilderExtension
    {
        /// <summary>
        /// Adds all validators for the domain models to the dependency container
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        internal static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<MaterialValidator>();
            return services;
        }
    }
}
