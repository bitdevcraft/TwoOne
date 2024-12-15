using MediatR;

using TwoOne.Application.Abstraction.Messaging;
using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.UseCase.Authentication.Login;

public sealed record LoginCommand(LoginRequest Login)
    : ICommand<TokenResponse>;