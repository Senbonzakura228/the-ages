using MassTransit;

namespace API.Extensions.Configuration
{
    public static class MassTransitExtension
    {
        public static IServiceCollection AddMassTransitConfigurations(this IServiceCollection services, string userName, string password)
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<UserRegisteredConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host("rabbitmq", h =>
                    {
                        h.Username(userName);
                        h.Password(password);
                    });

                    cfg.ReceiveEndpoint("user-registered-queue", ep =>
                    {
                        ep.UseMessageRetry(r => r.Interval(3, TimeSpan.FromSeconds(5)));
                        ep.ConfigureConsumer<UserRegisteredConsumer>(context);
                    });
                });
            });
            return services;
        }
    }
}