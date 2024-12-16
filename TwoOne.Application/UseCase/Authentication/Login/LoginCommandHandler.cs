using Microsoft.AspNetCore.Identity;
using TwoOne.Application.Abstraction.Jwt;
using TwoOne.Application.Abstraction.Messaging;
using TwoOne.Domain.Common.Repositories;
using TwoOne.Domain.Common.Shared.Results;
using TwoOne.Domain.Entities.Users;
using TwoOne.Domain.Entities.Users.RefreshTokens;

namespace TwoOne.Application.UseCase.Authentication.Login;

public class LoginCommandHandler(
    UserManager<User> userManager,
    IJwtProvider jwtProvider,
    IRefreshTokenRepository refreshTokenRepository
)
    : ICommandHandler<LoginCommand, TokenResponse>
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;

    public async Task<Result<TokenResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        User? user = await _userManager.FindByNameAsync(request.Login.Username);

        if (user == null || !await _userManager.CheckPasswordAsync(user, request.Login.Password))
        {
            return Result<TokenResponse>.FailureResult("login_failure");
        }

        string jwtToken = _jwtProvider.GenerateToken(user);
        Result<RefreshToken> refreshToken = await _refreshTokenRepository.CreateTokenAsync(user.Id);

        return Result<TokenResponse>
            .SuccessResult(new TokenResponse(
                jwtToken,
                refreshToken.Value!.Token
            ));
    }
}
