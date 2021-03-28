using CK.Lum.Material.Domain.Validator;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CK.Lum.Material.Api.Extensions
{
    internal static class ValidatorServiceBuilderExtension
    {
        internal static IServiceCollection ConfigureValidators(this IServiceCollection services)
        {
            services.AddScoped<MaterialValidator>();
            return services;
        }
    }
}
