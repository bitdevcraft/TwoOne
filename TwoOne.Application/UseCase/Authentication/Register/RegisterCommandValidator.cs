using FluentValidation;

namespace TwoOne.Application.UseCase.Authentication.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor((RegisterCommand r) => r.Register.Email)
            .EmailAddress()
            .NotEmpty();

        RuleFor((RegisterCommand r) => r.Register.Password)
            .NotEmpty();

        RuleFor((RegisterCommand r) => r.Register.UserName)
            .NotEmpty();
    }
}
