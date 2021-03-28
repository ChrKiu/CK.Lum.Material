using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CK.Lum.Material.Data.Mapping;
using CK.Lum.Material.Data.RavenDb;
using CK.Lum.Material.Data.Repositories;
using CK.Lum.Material.Domain.Models.MaterialAggregate;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CK.Lum.Material.Data.ServiceBuilderExtensions
{
    public static class ServiceBuilderExtension
    {
        public static IServiceCollection ConfigureDbContexts(this IServiceCollection services)
        {
            services.AddSingleton<RavenDbContext>();

            return services;
        }

        public static IServiceCollection ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMaterialRepository, MaterialRepository>();

            return services;
        }

        public static IServiceCollection ConfigureMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg => {
                cfg.AddMaps(Assembly.GetAssembly(typeof(MaterialProfile)));
                cfg.AddExpressionMapping();
            });

            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }
    }
}
