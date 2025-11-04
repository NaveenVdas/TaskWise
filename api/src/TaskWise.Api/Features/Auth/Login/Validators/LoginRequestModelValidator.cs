using FluentValidation;

namespace TaskWise.Api.Features.Auth.Login.Validators;

public sealed class LoginRequestModelValidator : AbstractValidator<LoginRequestModel>
{
    public LoginRequestModelValidator()
    {
        RuleFor(p => p.Email)
            .NotEmpty()
            .EmailAddress();

        RuleFor(p => p.Password)
            .NotEmpty()
            .Must(password => !string.IsNullOrWhiteSpace(password));
    }
}
