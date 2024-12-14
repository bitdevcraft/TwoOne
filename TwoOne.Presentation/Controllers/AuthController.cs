using MediatR;

using Microsoft.AspNetCore.Mvc;

using TwoOne.Application.UseCase.Authentication.Login;
using TwoOne.Domain.Common.Shared.Results;
using TwoOne.Presentation.Abstraction;

namespace TwoOne.Presentation.Controllers;

public class AuthController(ISender sender) : ApiController(sender)
{

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginRequest request)
    {
        var query = new LoginCommand(request);
        Result<LoginResponse> result = await _sender.Send(query);
    
        return result.Success ? Ok(result.Value) : BadRequest(result.Errors);
    }
    
}