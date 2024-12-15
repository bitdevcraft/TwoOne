using TwoOne.Application.Abstraction.Messaging;
using TwoOne.Application.UseCase.Authentication.Login;

namespace TwoOne.Application.UseCase.Authentication.Refresh;

public record RefreshTokenCommand(string RefreshToken) : ICommand<TokenResponse>;