using AspNetCore6.BugTracker.Services.Interfaces;
using AspNetCore6.BugTracker.ViewModels.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore6.BugTracker.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<ActionResult<JwtViewModel>> Login(LoginViewModel viewModel) {
        return Ok(await _authService.LoginAsync(viewModel));
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserCreateViewModel viewModel)
    {
        await _authService.RegisterAsync(viewModel);
        return Ok();
    }
}