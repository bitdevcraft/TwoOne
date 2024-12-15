using Microsoft.AspNetCore.Identity;

using TwoOne.Application.Abstraction.Jwt;
using TwoOne.Application.Abstraction.Messaging;
using TwoOne.Application.UseCase.Authentication.Login;
using TwoOne.Domain.Common.Repositories;
using TwoOne.Domain.Common.Shared.Results;
using TwoOne.Domain.Entities.Users;

namespace TwoOne.Application.UseCase.Authentication.Refresh;

public class RefreshTokenCommandHandler(
    IRefreshTokenRepository refreshTokenRepository,
    UserManager<User> userManager,
    IJwtProvider jwtProvider)
    : ICommandHandler<RefreshTokenCommand, TokenResponse>
{
    private readonly IRefreshTokenRepository _refreshTokenRepository = refreshTokenRepository;
    private readonly UserManager<User> _userManager = userManager;
    private readonly IJwtProvider _jwtProvider = jwtProvider;

    public async Task<Result<TokenResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var token = await _refreshTokenRepository.GetTokenAsync(request.RefreshToken);

        if (token == null || token.Expires < DateTime.UtcNow || token.IsUsed || token.IsRevoked)
        {
            return Result<TokenResponse>.FailureResult("Invalid or expired refresh token");
        }

        // Mark the token as used
        await _refreshTokenRepository.MarkTokenAsUsedAsync(token);

        // Generate new tokens
        var user = await _userManager.FindByIdAsync(token.UserId!);

        if (user == null)
        {
            return Result<TokenResponse>.FailureResult("Invalid or expired refresh token");
        }
        
        var jwtToken = _jwtProvider.GenerateToken(user);
        var newRefreshToken = await _refreshTokenRepository.CreateTokenAsync(user.Id);

        return Result<TokenResponse>
            .SuccessResult(new TokenResponse(
                jwtToken,
                newRefreshToken.Value!.Token
            ));
    }
}