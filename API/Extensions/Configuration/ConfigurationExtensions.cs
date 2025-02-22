using Application.Authentication;
using Data;
using Data.Presets;

namespace API.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtOptions>(configuration.GetSection(nameof(JwtOptions)));
            services.Configure<CityExtentionOptions>(configuration.GetSection(nameof(CityExtentionOptions)));
            services.Configure<BuildingOptions>(configuration.GetSection(nameof(BuildingOptions)));

            return services;
        }
    }
}