namespace TwoOne.Application.UseCase.Authentication.Register;

public record RegisterRequest(
    string UserName,
    string Email,
    string Password
);
