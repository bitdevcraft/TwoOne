using FluentValidation;

namespace TwoOne.Application.UseCase.Authentication.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(r => r.Register.Email)
            .EmailAddress()
            .NotEmpty();

        RuleFor(r => r.Register.Password)
            .NotEmpty();

        RuleFor(r => r.Register.UserName)
            .NotEmpty();
    }
}