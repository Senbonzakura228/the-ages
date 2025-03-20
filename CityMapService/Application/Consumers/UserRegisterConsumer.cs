using Application.DTO;
using Infrastructure.Repositories;
using MassTransit;

public class UserRegisteredConsumer : IConsumer<RegistredUser>
{
    private CityMapRepository cityMapRepository;
    public UserRegisteredConsumer(CityMapRepository cityMapRepository)
    {
        this.cityMapRepository = cityMapRepository;
    }
    public async Task Consume(ConsumeContext<RegistredUser> context)
    {
        await cityMapRepository.Add(context.Message.userId);
    }
}