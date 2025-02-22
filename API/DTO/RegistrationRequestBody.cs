namespace API.DTO
{
    public record RegistrationRequestBody(
        string userName,
        string password
    );
}