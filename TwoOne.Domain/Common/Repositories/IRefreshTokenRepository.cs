using TwoOne.Domain.Common.Shared.Results;
using TwoOne.Domain.Entities.Users.RefreshTokens;

namespace TwoOne.Domain.Common.Repositories;

public interface IRefreshTokenRepository
{
    Task<Result<RefreshToken>> CreateTokenAsync(string userId);
    Task<RefreshToken?> GetTokenAsync(string token);
    Task MarkTokenAsUsedAsync(RefreshToken token);
}