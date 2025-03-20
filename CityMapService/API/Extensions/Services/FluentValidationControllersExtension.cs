using API.Validation;
using FluentValidation.AspNetCore;

namespace API.Extensions.Services
{
    public static class FluentValidationControllersExtension
    {
        public static IServiceCollection AddFluentValidation(this IServiceCollection services)
        {
            services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BuildingPlaceValidator>());
            return services;
        }
    }
}