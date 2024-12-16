using TwoOne.Domain.Common;

namespace TwoOne.Domain.Entities.Users.RefreshTokens;

public class RefreshToken : BaseEntity
{
    public string? Token { get; set; }
    public string? UserId { get; set; }
    public User? User { get; set; }
    public DateTime Expires { get; set; }
    public bool IsRevoked { get; set; }
    public bool IsUsed { get; set; }
    public DateTime Created { get; set; }
    public DateTime? RevokedAt { get; set; }
}
