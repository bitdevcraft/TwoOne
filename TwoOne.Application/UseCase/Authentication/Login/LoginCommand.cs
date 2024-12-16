using TwoOne.Application.Abstraction.Messaging;

namespace TwoOne.Application.UseCase.Authentication.Login;

/// <summary>
/// 
/// </summary>
/// <param name="Login"></param>
public sealed record LoginCommand(LoginRequest Login)
    : ICommand<TokenResponse>;
