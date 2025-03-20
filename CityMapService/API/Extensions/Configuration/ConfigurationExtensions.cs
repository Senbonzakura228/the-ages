using Infrastructure;
using Infrastructure.Presets;

namespace API.Extensions.Configuration
{
    public static class ConfigurationExtensions
    {
        public static IServiceCollection AddCustomConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CityExtentionOptions>(configuration.GetSection(nameof(CityExtentionOptions)));
            services.Configure<BuildingOptions>(configuration.GetSection(nameof(BuildingOptions)));
            return services;
        }
    }
}