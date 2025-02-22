using Application.Authentication;
using Application.Services;
using Data.Repositories;

namespace API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddAllCustomServices(this IServiceCollection services)
        {
            services.AddJwtServices();
            services.AddUserServices();
            services.AddPlacementServices();
            services.AddUserRepositoryServices();
            services.AddPlacementRepositoryServices();
            return services;
        }

        public static IServiceCollection AddUserServices(this IServiceCollection services)
        {
            services.AddScoped<AuthService>();
            return services;
        }

        public static IServiceCollection AddJwtServices(this IServiceCollection services)
        {
            services.AddScoped<JwtOptions>();
            services.AddScoped<JwtGenerator>();
            return services;
        }

        public static IServiceCollection AddPlacementServices(this IServiceCollection services)
        {
            services.AddScoped<BuildingPlacementService>();
            services.AddScoped<CityMapService>();
            return services;
        }

        public static IServiceCollection AddUserRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<UserAccountRepository>();
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