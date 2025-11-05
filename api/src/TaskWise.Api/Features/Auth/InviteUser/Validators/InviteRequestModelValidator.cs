using FluentValidation;

namespace TaskWise.Api.Features.Auth.InviteUser.Validators;

public class InviteRequestModelValidator : AbstractValidator<InviteRequestModel>
{
    public InviteRequestModelValidator()
    {
        RuleFor(x => x.LastName)
            .NotEmpty()
            .Must(n => !string.IsNullOrWhiteSpace(n));
        RuleFor(x => x.Email)
            .NotEmpty()
            .EmailAddress();
        RuleFor(x => x.Role)
            .IsInEnum();
        RuleFor(x => x.InvitedBy)
            .GreaterThan(0);
    }
}
