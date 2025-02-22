namespace API.DTO
{
    public record LoginRequestBody(
        string userName,
        string password
    );
}