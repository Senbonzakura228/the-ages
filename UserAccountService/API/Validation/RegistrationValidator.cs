using Application.DTO;
using FluentValidation;

namespace API.Validation
{
    public class RegistrationValidator : AbstractValidator<RegistrationRequestBody>
    {
        private readonly int _usernameMinLength = 5;
        private readonly int _passwordMinLength = 5;
        public RegistrationValidator()
        {
            RuleFor(x => x.userName)
            .NotEmpty().WithMessage("username is required")
            .MinimumLength(_usernameMinLength).WithMessage("username min length must be " + _usernameMinLength);

            RuleFor(x => x.password)
            .NotEmpty().WithMessage("password is required")
            .MinimumLength(_passwordMinLength).WithMessage("password min length must be " + _passwordMinLength);
        }
    }
}