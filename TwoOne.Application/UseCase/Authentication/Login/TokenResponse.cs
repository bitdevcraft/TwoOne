namespace TwoOne.Application.UseCase.Authentication.Login;

public record TokenResponse(string Token, string? RefreshToken);