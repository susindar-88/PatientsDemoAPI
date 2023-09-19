using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace TokenProvider.Controllers;

[ApiController]
[Route("[controller]")]
public class TokenController : ControllerBase
{
    private readonly UserAccountService _userAuthService;

    public TokenController(UserAccountService userAuthService)
    {
        _userAuthService = userAuthService;
    }

    [HttpPost(Name = "GetToken")]
    [AllowAnonymous]
    public ActionResult<UserSession> Post(LoginRequest loginRequest)
    {
        var jwtManager = new JwtAuthManager(_userAuthService);
        var userSession = jwtManager.GenerateJwtToken(loginRequest.UserName, loginRequest.Password);
        if (userSession == null)
            return Unauthorized();

        return userSession;
    }
}
