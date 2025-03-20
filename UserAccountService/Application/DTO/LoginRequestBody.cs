namespace Application.DTO
{
    public record LoginRequestBody(
        string userName,
        string password
    );
}