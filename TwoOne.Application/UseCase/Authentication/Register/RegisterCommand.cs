using TwoOne.Application.Abstraction.Messaging;

namespace TwoOne.Application.UseCase.Authentication.Register;

public record RegisterCommand(
    RegisterRequest Register
) : ICommand;