namespace Application.DTO
{
    public record RegistrationRequestBody(
        string userName,
        string password
    );
}