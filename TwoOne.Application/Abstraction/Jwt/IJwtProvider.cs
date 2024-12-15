using TwoOne.Domain.Entities.Users;

namespace TwoOne.Application.Abstraction.Jwt;

public interface IJwtProvider
{
    string GenerateToken(User user);
}