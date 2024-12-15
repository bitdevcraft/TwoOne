using Microsoft.EntityFrameworkCore;

using TwoOne.Domain.Common.Repositories;
using TwoOne.Domain.Common.Shared.Results;
using TwoOne.Domain.Entities.Users.RefreshTokens;

namespace TwoOne.Persistence.Repositories.RefreshTokens;

public class RefreshTokenRepository(AppDbContext context) : IRefreshTokenRepository
{
    private readonly AppDbContext _context = context;
    private readonly DbSet<RefreshToken> _dbSet = context.Set<RefreshToken>();

    public async Task<Result<RefreshToken>> CreateTokenAsync(string userId)
    {
        var refreshToken = new RefreshToken
        {
            Token = Guid.NewGuid().ToString(),
            UserId = userId,
            Expires = DateTime.UtcNow.AddDays(7), // Example: 7 days expiration
            Created = DateTime.UtcNow,
            IsUsed = false,
            IsRevoked = false
        };

        _dbSet.Add(refreshToken);
        var result = await _context.SaveChangesAsync() > 0;

        if (!result)
        {
            Result<RefreshToken>.FailureResult("Failed to create refresh token");
        }
        
        return Result<RefreshToken>.SuccessResult(refreshToken);
    }

    public async Task<RefreshToken?> GetTokenAsync(string token)
    {
        return await _dbSet
            .FirstOrDefaultAsync(
                t =>
                    t.Token == token && !t.IsUsed && !t.IsRevoked
            );
    }

    public async Task MarkTokenAsUsedAsync(RefreshToken token)
    {
        token.IsUsed = true;
        await _context.SaveChangesAsync();
    }
}