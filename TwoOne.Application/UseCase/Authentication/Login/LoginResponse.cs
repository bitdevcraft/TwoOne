namespace TwoOne.Application.UseCase.Authentication.Login;

public record LoginResponse(string Token, string RefreshToken);