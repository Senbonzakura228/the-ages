using API.Validation;
using FluentValidation.AspNetCore;

namespace API.Extensions.Services
{
    public static class FluentValidationControllersExtension
    {
        public static IServiceCollection AddControllersWithFluentValidation(this IServiceCollection services)
        {
            services.AddControllers()
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<BuildingPlaceValidator>())
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<LoginValidator>())
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<RegistrationValidator>());

            return services;
        }
    }
}