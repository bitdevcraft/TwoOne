// Copyright (c) Ryan Capio.
// All Rights Reserved.

using TwoOne.Domain.Entities.Users;

namespace TwoOne.Application.Abstraction.Jwt;

/// <summary>
/// 
/// </summary>
public interface IJwtProvider
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    string GenerateToken(User user);
}
