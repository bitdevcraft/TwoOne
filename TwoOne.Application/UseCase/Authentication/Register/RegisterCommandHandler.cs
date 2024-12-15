using Microsoft.AspNetCore.Identity;

using TwoOne.Application.Abstraction.Messaging;
using TwoOne.Domain.Common.Shared.Results;
using TwoOne.Domain.Entities.Users;

namespace TwoOne.Application.UseCase.Authentication.Register;

public class RegisterCommandHandler: ICommandHandler<RegisterCommand>
{
    private readonly UserManager<User> _userManager;

    public RegisterCommandHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }
    
    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            UserName = request.Register.UserName,
            Email = request.Register.Email,
        };
        
        IdentityResult result = await _userManager.CreateAsync(user, request.Register.Password);

        if (!result.Succeeded)
        {
            return Result.FailureResult("Failed to create user");
        }
        
        return Result.SuccessResult();
    }
}