using Application.Services;
using Infrastructure.Repositories;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
        {
            services.AddPlacementServices();
            services.AddPlacementRepositoryServices();
            return services;
        }

        public static IServiceCollection AddPlacementServices(this IServiceCollection services)
        {
            services.AddScoped<BuildingPlacementService>();
            services.AddScoped<CityMapService>();
            return services;
        }

        public static IServiceCollection AddPlacementRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<CityMapRepository>();
            services.AddScoped<BuildingRepository>();
            return services;
        }
    }
}