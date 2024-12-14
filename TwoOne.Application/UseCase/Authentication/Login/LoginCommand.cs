using MediatR;

using TwoOne.Domain.Common.Shared.Results;

namespace TwoOne.Application.UseCase.Authentication.Login;

public sealed record LoginCommand(LoginRequest Login)
    : IRequest<Result<LoginResponse>>;