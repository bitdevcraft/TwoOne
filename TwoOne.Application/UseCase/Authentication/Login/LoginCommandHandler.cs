using MediatR;
using Microsoft.AspNetCore.Identity;

using TwoOne.Domain.Common.Shared.Results;
using TwoOne.Domain.Entities.Users;

namespace TwoOne.Application.UseCase.Authentication.Login;

public class LoginCommandHandler(
    SignInManager<User> signInManager
)
    : IRequestHandler<LoginCommand, Result<LoginResponse>>
{
    private readonly SignInManager<User> _signInManager = signInManager;

    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        SignInResult? result = await _signInManager.PasswordSignInAsync(
            request.Login.Username, request.Login.Password, false, false
        );

        return !result.Succeeded
            ? Result<LoginResponse>.FailureResult("login_failure")
            : Result<LoginResponse>.SuccessResult(new LoginResponse("", ""));
    }
}